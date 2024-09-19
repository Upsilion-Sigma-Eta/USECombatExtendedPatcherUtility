using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USECEAPG_Main.Logic
{
    public class CEProjectile : VanillaCompatProjectile
    {
        public string ShellingProps { get; set; }
        public double PelletCount { get; set; }
        public double SpreadMult { get; set; }
        public double SecondaryDamage { get; set; }
        public string DamageAdjacentTiles { get; set; }
        public string DropsCasing { get; set; }
        public string CasingMoteDefName { get; set; }
        public string CasingFilthDefName { get; set; }
        public double GravityFactor { get; set; }
        public string IsInstant { get; set; }

        public string DamageFalloff { get; set; }
        public double ArmorPenetrationSharp { get; set; }
        public double ArmorPenetrationBlunt { get; set; }

        public string CastShadows { get; set; }
        public double SuppressionFactor { get; set; }
        public double AirborneSuppressionFactor { get; set; }
        public double DamageFactor { get; set; }
        public double BallisticCoefficient_Min { get; set; }
        public double BallisticCoefficient_Max { get; set; }

        public double Mass { get; set; }
        public double Diameter { get; set; }

        public string LerpPositions { get; set; }
        public string DetonateMoteDef { get; set; }

        public double FuseDelay { get; set; }
        public string HP_Penetration { get; set; }
        public string HP_Penetration_Ratio { get; set; }
        public double ArmingDelay { get; set; }
        public double AimHeightOffset { get; set; }
        public double EMPShellBreakChance { get; set; }
    }
}
