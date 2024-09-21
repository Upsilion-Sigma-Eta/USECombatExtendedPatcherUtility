using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USECEAPG_Main.Logic
{
    public class CEAmmo
    {
        public string AmmoClass { get; set; }
        public double AmmoCount { get; set; }
        public string AmmoSetDefs { get; set; }
        public List<string> AmmoTags { get; set; }
        public double CookOffFlashScale { get; set; }
        public string CookOffProjectile { get; set; }
        public string CookOffSound { get; set; }
        public double CookOffSpeed { get; set; }
        public string CookOffTailSound { get; set; }
        public double DefaultAmmoCount { get; set; }
        public string DetonateProjectile { get; set; }
        public string IsMortarAmmo { get; set; }
        public string SpawnAsSiegeAmmo { get; set; }
    }
}
