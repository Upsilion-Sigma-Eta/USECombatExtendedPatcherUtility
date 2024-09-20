using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using USECEAPG_Main.Logic;

namespace USECEAPG_Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Logic.Manager.Instance.GUI_MainWindow = this;
        }

        private void _ldPresetSetting_Btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void _ldModFolder_Btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFolderDialog folderDialog = new OpenFolderDialog();

            if (folderDialog.ShowDialog() == true)
            {
                Logic.Manager.Instance.GUI_MainWindow._weaponsList_LB.Items.Clear();
                Logic.Manager.Instance.VanillaWeaponData.Clear();

                DirectoryInfo rootDirectory = new DirectoryInfo(folderDialog.FolderName);

                DirectoryInfo[] subDirectories = rootDirectory.GetDirectories();

                foreach (DirectoryInfo directory in subDirectories)
                {
                    FileInfo[] xmlFiles = directory.GetFiles("*.xml");

                    foreach (FileInfo file in xmlFiles)
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.Load(file.FullName);

                        List<VanillaCompatWeapon> weapons = VanillaXMLLoader.GetVanillaWeapon(xml);

                        if (!weapons.IsNullOrEmpty())
                        {
                            Logic.Manager.Instance.XMLFileHandler.Files.Add(file);
                            Logic.Manager.Instance.XMLFileHandler.Directories.Add(directory);
                            Logic.Manager.Instance.VanillaWeaponData.AddRange(weapons);
                        }
                    }
                }

                FileInfo[] xmlFilesInRoot = rootDirectory.GetFiles("*.xml");

                foreach (FileInfo file in xmlFilesInRoot)
                {
                    XmlDocument xml = new XmlDocument();
                    xml.Load(file.FullName);

                    List<VanillaCompatWeapon> weapons = VanillaXMLLoader.GetVanillaWeapon(xml);

                    if (!weapons.IsNullOrEmpty())
                    {
                        Logic.Manager.Instance.XMLFileHandler.Files.Add(file);
                        Logic.Manager.Instance.XMLFileHandler.Directories.Add(rootDirectory);
                        Logic.Manager.Instance.VanillaWeaponData.AddRange(weapons);
                    }
                }
            }

            if (!Logic.Manager.Instance.VanillaWeaponData.IsNullOrEmpty())
            {
                Logic.Manager.Instance.GUI_MainWindow._weaponDataPanel_gui.VanillaWeapon = Logic.Manager.Instance.VanillaWeaponData.First();
                
                foreach (VanillaCompatWeapon weapon in Logic.Manager.Instance.VanillaWeaponData)
                {
                    Logic.Manager.Instance.GUI_MainWindow._weaponsList_LB.Items.Add(weapon.Label);
                }
            }
        }

        private void _weaponsList_LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TODO : 인덱스가 선택되어 있지 않은 상태에서 다른 폴더의 아이템을 불러왔을 때 처리 로직 추가
            Logic.Manager.Instance.GUI_MainWindow._weaponDataPanel_gui.VanillaWeapon = Logic.Manager.Instance.VanillaWeaponData[_weaponsList_LB.SelectedIndex];
        }
    }
}