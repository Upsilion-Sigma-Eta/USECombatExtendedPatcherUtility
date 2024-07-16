using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USECEAPG_Main.Logic
{
    public class VanillaCompatProjectile
    {
        public string DefName { get; set; }
        public string Label { get; set; }
        public string DamageDef { get; set; }
        public int DamageAmountBase { get; set; } 
        public int StoppingPower { get; set; }
        public int Speed { get; set; }
        public VanillaCompatGraphicData Graphic { get; set; }
    }
}
