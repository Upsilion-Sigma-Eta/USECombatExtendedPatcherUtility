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
        public double DamageAmountBase { get; set; } 
        public double StoppingPower { get; set; }
        public double Speed { get; set; }
        public VanillaCompatGraphicData Graphic { get; set; }
    }
}
