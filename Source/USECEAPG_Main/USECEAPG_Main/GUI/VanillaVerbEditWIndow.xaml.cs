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
using System.Windows.Shapes;
using USECEAPG_Main.Logic;

namespace USECEAPG_Main.GUI
{
    /// <summary>
    /// VanillaVerbEditWIndow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class VanillaVerbEditWIndow : Window
    {
        private VanillaCompatWeapon _vanillaCompatWeapon;

        public VanillaVerbEditWIndow(VanillaCompatWeapon weapons, VanillaCompatVerb vanillaCompatVerb)
        {
            InitializeComponent();
            _vanillaCompatWeapon = weapons;
        }
    }
}
