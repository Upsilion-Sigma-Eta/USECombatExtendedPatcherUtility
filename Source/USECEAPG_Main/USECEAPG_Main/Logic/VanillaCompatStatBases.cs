using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USECEAPG_Main.Logic
{
    public class VanillaCompatStatBases
    {
        public int WorkToMake { get; set; }
        public int Mass { get; set; }
        public double AccuracyTouch { get; set; }
        public double AccuracyShort { get; set; }
        public double AccuracyMedium { get; set; }
        public double AccuracyLong { get; set; }
        public int RangedWeaponCooldown { get; set; }
    }
}
