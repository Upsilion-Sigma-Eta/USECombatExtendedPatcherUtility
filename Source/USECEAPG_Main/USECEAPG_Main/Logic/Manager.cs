using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USECEAPG_Main.GUI;

namespace USECEAPG_Main.Logic
{
    public class Manager
    {
        private static Manager _instance;

        MainWindow _gui_mainWindow;

        XMLFileHandling _xmlFileHandler;
        List<VanillaCompatWeapon> _vanillaWeaponData;
        List<VanillaCompatProjectile> _vanillaProjectileData;

        public static Manager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Manager();
                }
                return _instance;
            }
        }

        public MainWindow GUI_MainWindow
        {
            get 
            { 
                return _gui_mainWindow; 
            }
            set 
            { 
                _gui_mainWindow = value; 
            }
        }

        public XMLFileHandling XMLFileHandler
        {
            get
            {
                return _xmlFileHandler;
            }
        }

        public List<VanillaCompatWeapon> VanillaWeaponData
        {
            get
            {
                return _vanillaWeaponData;
            }
        }

        private Manager()
        {
            _xmlFileHandler = new XMLFileHandling();
            _vanillaWeaponData = new List<VanillaCompatWeapon>();
        }
    }
}
