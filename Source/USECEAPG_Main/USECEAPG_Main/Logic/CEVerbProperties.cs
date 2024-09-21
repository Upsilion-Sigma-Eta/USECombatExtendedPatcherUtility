using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USECEAPG_Main.Logic
{
    public class CEVerbProperties : VanillaCompatVerb
    {
        public string RecoilPattern { get; set; }
        public double AmmoConsumePerShotCount { get; set; }
        public double RecoilAmount { get; set; }
        public double IndirectFirePenalty { get; set; }
        public double CircularError { get; set; }
        public double MeleeArmorPenetration { get; set; }
        public string EjectsCasing { get; set; }
        public string IgnorePartialLosBlocker { get; set; }
        public string InterruptibleBurstShot { get; set; }
    }
}
