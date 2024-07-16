using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace USECEAPG_Main.Logic
{
    public class VanillaCompatVerb
    {
        public string VerbClassName { get; set; }
        public bool HasStandardCommand { get; set; }
        public string DefaultProjectile { get; set; }
        public double WarmupTime { get; set; }
        public double Range { get; set; }
        public int MuzzleFlashScale { get; set; }
    }
}
