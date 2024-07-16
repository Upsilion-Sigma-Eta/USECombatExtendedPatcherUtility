using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USECEAPG_Main.Logic
{
    public class VanillaCompatWeapon
    {
        public string DefName { get; set; }
        public string Label { get; set; }
        public List<string> WeaponTags { get; set; }
        public List<string> WeaponClasses { get; set; }
        public VanillaCompatStatBases WeaponBaseStats { get; set; }
        public List<VanillaCompatVerb> Verbs { get; set; }
        public List<VanillaCompatTool> MeleeTools { get; set; }

        public VanillaCompatGraphicData Graphic { get; set; }
        
        public VanillaCompatWeapon()
        {
            DefName = "None";
            Label = "None";
            WeaponTags = new List<string>();
            WeaponClasses = new List<string>();
            Verbs = new List<VanillaCompatVerb>();
            MeleeTools = new List<VanillaCompatTool>();
        }
    }
}
