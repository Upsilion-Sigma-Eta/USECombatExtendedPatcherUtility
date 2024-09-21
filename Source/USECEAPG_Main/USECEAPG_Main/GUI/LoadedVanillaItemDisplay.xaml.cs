using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using USECEAPG_Main.Logic;

namespace USECEAPG_Main.GUI
{
    /// <summary>
    /// LoadedVanillaItemDisplay.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoadedVanillaItemDisplay : UserControl
    {
        VanillaCompatWeapon _vanillaWeaponData;

        public LoadedVanillaItemDisplay()
        {
            InitializeComponent();
        }

        public VanillaCompatWeapon VanillaWeapon
        {
            get
            {
                return _vanillaWeaponData;
            }
            set
            {
                _vanillaWeaponData = value;

                _defNameActual_TB.Text = _vanillaWeaponData.DefName;
                _label_TB.Text = _vanillaWeaponData.Label;
            }
        }

        private void _verbList_LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void _editVerbsInfo_Btn_Click(object sender, RoutedEventArgs e)
        {
            VanillaVerbEditWIndow display = new VanillaVerbEditWIndow(_vanillaWeaponData);
            display.Show();
        }
    }
}
