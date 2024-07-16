using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;

namespace USECEAPG_Main.Logic
{
    public static class VanillaXMLLoader
    {
        public static List<VanillaCompatWeapon> GetVanillaWeapon(XmlDocument xml)
        {
            // 로드된 XML 문서에서 각 ThingDef 불러오기
            XmlNodeList weaponDefs = xml.SelectNodes("/Defs/ThingDef");

            if (weaponDefs.IsNullOrEmpty())
            {
                return null;
            }

            // XML 노드 리스트에서 바닐라 무기 정보 추출

            List<VanillaCompatWeapon> weapons = new List<VanillaCompatWeapon>();
            for (int nodeIndex = 0; nodeIndex < weaponDefs.Count; ++nodeIndex)
            {
                VanillaCompatWeapon vanillaCompatWeapon = new VanillaCompatWeapon();
                vanillaCompatWeapon.DefName = weaponDefs[nodeIndex].SelectSingleNode("defName").InnerText;
                vanillaCompatWeapon.Label = weaponDefs[nodeIndex].SelectSingleNode("label").InnerText;
                
                foreach (XmlNode node in weaponDefs[nodeIndex].SelectNodes("weaponTags/li"))
                {
                    vanillaCompatWeapon.WeaponTags.Add(node.InnerText);
                }

                // 무기의 기본 스탯 추출
                vanillaCompatWeapon.WeaponBaseStats = new VanillaCompatStatBases();
                vanillaCompatWeapon.WeaponBaseStats.WorkToMake = Convert.ToInt32(weaponDefs[nodeIndex].SelectSingleNode("statBases/WorkToMake").InnerText);
                vanillaCompatWeapon.WeaponBaseStats.Mass = Convert.ToInt32(weaponDefs[nodeIndex].SelectSingleNode("statBases/Mass").InnerText);
                vanillaCompatWeapon.WeaponBaseStats.AccuracyTouch = Convert.ToDouble(weaponDefs[nodeIndex].SelectSingleNode("statBases/AccuracyTouch").InnerText);
                vanillaCompatWeapon.WeaponBaseStats.AccuracyShort = Convert.ToDouble(weaponDefs[nodeIndex].SelectSingleNode("statBases/AccuracyShort").InnerText);
                vanillaCompatWeapon.WeaponBaseStats.AccuracyMedium = Convert.ToDouble(weaponDefs[nodeIndex].SelectSingleNode("statBases/AccuracyMedium").InnerText);
                vanillaCompatWeapon.WeaponBaseStats.AccuracyLong = Convert.ToDouble(weaponDefs[nodeIndex].SelectSingleNode("statBases/AccuracyLong").InnerText);
                vanillaCompatWeapon.WeaponBaseStats.RangedWeaponCooldown = Convert.ToInt32(weaponDefs[nodeIndex].SelectSingleNode("statBases/RangedWeapon_Cooldown").InnerText);

                // 무기의 그래픽 데이터 경로 확인
                vanillaCompatWeapon.Graphic = new VanillaCompatGraphicData();
                vanillaCompatWeapon.Graphic.TexturePath = weaponDefs[nodeIndex].SelectSingleNode("graphicData/texPath").InnerText;

                // 무기의 공격 동사 관련 정보 추출
                vanillaCompatWeapon.Verbs = new List<VanillaCompatVerb>();
                
                foreach (XmlNode node in weaponDefs[nodeIndex].SelectNodes("verbs/li"))
                {
                    VanillaCompatVerb verb = new VanillaCompatVerb();
                    verb.VerbClassName = node.SelectSingleNode("verbClass").InnerText;
                    verb.HasStandardCommand = Convert.ToBoolean(node.SelectSingleNode("hasStandardCommand").InnerText);
                    verb.Range = Convert.ToInt32(node.SelectSingleNode("range").InnerText);
                    verb.WarmupTime = Convert.ToDouble(node.SelectSingleNode("warmupTime").InnerText);
                    verb.MuzzleFlashScale = Convert.ToInt32(node.SelectSingleNode("muzzleFlashScale").InnerText);
                    verb.DefaultProjectile = node.SelectSingleNode("defaultProjectile").InnerText;
                    vanillaCompatWeapon.Verbs.Add(verb);
                }

                // 무기의 근접 공격 관련 정보 추출
                vanillaCompatWeapon.MeleeTools = new List<VanillaCompatTool>();

                foreach (XmlNode node in weaponDefs[nodeIndex].SelectNodes("tools/li"))
                {
                    VanillaCompatTool tool = new VanillaCompatTool();

                    tool.Label = node.SelectSingleNode("label").InnerText;
                    
                    tool.Capacities = new List<string>();
                    foreach (XmlNode node_capacities in node.SelectNodes("li"))
                    {
                        tool.Capacities.Add(node_capacities.Value);
                    }

                    tool.Power = Convert.ToInt32(node.SelectSingleNode("power").InnerText);
                    tool.CooldownTime = Convert.ToInt32(node.SelectSingleNode("cooldownTime").InnerText);
                }

                weapons.Add(vanillaCompatWeapon);
            }

            return weapons;
        }

        public static VanillaCompatProjectile GetProjectileInfo(XmlDocument xml, string defName)
        {
            VanillaCompatProjectile projectile = new VanillaCompatProjectile();

            XmlNode projectileNode = xml.SelectSingleNode($"/Defs/ThingDef[defName='{defName}']");

            projectile.DefName = projectileNode.SelectSingleNode("defName").InnerText;
            projectile.Label = projectileNode.SelectSingleNode("label").InnerText;
            projectile.Speed = Convert.ToInt32(projectileNode.SelectSingleNode("projectile/speed").InnerText);
            projectile.DamageDef = projectileNode.SelectSingleNode("projectile/damageDef").InnerText;
            projectile.DamageAmountBase = Convert.ToInt32(projectileNode.SelectSingleNode("projectile/damageAmountBase").InnerText);
            projectile.StoppingPower = Convert.ToInt32(projectileNode.SelectSingleNode("projectile/stoppingPower").InnerText);

            return projectile;
        }
    }
}
