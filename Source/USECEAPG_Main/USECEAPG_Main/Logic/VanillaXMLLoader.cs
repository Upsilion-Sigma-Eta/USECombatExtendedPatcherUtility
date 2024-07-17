using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;

namespace USECEAPG_Main.Logic
{
    public static class VanillaXMLLoader
    {
        public static List<VanillaCompatWeapon> GetVanillaWeapon(XmlDocument xml)
        {
            try
            {
                List<VanillaCompatWeapon> weapons = new List<VanillaCompatWeapon>();
                XmlNodeList weaponDefs = xml.SelectNodes("/Defs/ThingDef");

                if (weaponDefs.IsNullOrEmpty())
                {
                    return null;
                }

                // XML 노드 리스트에서 바닐라 무기 정보 추출
                for (int nodeIndex = 0; nodeIndex < weaponDefs.Count; ++nodeIndex)
                {
                    VanillaCompatWeapon vanillaCompatWeapon = new VanillaCompatWeapon();
                    vanillaCompatWeapon.DefName = weaponDefs[nodeIndex].SelectSingleNode("defName")?.InnerText;
                    vanillaCompatWeapon.Label = weaponDefs[nodeIndex].SelectSingleNode("label")?.InnerText;

                    foreach (XmlNode node in weaponDefs[nodeIndex].SelectNodes("weaponTags/li"))
                    {
                        vanillaCompatWeapon.WeaponTags.Add(node?.InnerText);
                    }

                    // 무기의 기본 스탯 추출
                    vanillaCompatWeapon.WeaponBaseStats = new VanillaCompatStatBases();
                    vanillaCompatWeapon.WeaponBaseStats.WorkToMake = Convert.ToDouble(weaponDefs[nodeIndex].SelectSingleNode("statBases/WorkToMake")?.InnerText);
                    vanillaCompatWeapon.WeaponBaseStats.Mass = Convert.ToDouble(weaponDefs[nodeIndex].SelectSingleNode("statBases/Mass")?.InnerText);
                    vanillaCompatWeapon.WeaponBaseStats.AccuracyTouch = Convert.ToDouble(weaponDefs[nodeIndex].SelectSingleNode("statBases/AccuracyTouch")?.InnerText);
                    vanillaCompatWeapon.WeaponBaseStats.AccuracyShort = Convert.ToDouble(weaponDefs[nodeIndex].SelectSingleNode("statBases/AccuracyShort")?.InnerText);
                    vanillaCompatWeapon.WeaponBaseStats.AccuracyMedium = Convert.ToDouble(weaponDefs[nodeIndex].SelectSingleNode("statBases/AccuracyMedium")?.InnerText);
                    vanillaCompatWeapon.WeaponBaseStats.AccuracyLong = Convert.ToDouble(weaponDefs[nodeIndex].SelectSingleNode("statBases/AccuracyLong")?.InnerText);
                    vanillaCompatWeapon.WeaponBaseStats.RangedWeaponCooldown = Convert.ToDouble(weaponDefs[nodeIndex].SelectSingleNode("statBases/RangedWeapon_Cooldown")?.InnerText);

                    // 무기의 그래픽 데이터 경로 확인
                    vanillaCompatWeapon.Graphic = new VanillaCompatGraphicData();
                    vanillaCompatWeapon.Graphic.TexturePath = weaponDefs[nodeIndex].SelectSingleNode("graphicData/texPath")?.InnerText;

                    // 무기의 공격 동사 관련 정보 추출
                    vanillaCompatWeapon.Verbs = new List<VanillaCompatVerb>();

                    foreach (XmlNode node in weaponDefs[nodeIndex].SelectNodes("verbs/li"))
                    {
                        VanillaCompatVerb verb = new VanillaCompatVerb();
                        verb.VerbClassName = node.SelectSingleNode("verbClass")?.InnerText;
                        verb.HasStandardCommand = Convert.ToBoolean(node.SelectSingleNode("hasStandardCommand")?.InnerText);
                        verb.Range = Convert.ToDouble(node.SelectSingleNode("range")?.InnerText);
                        verb.WarmupTime = Convert.ToDouble(node.SelectSingleNode("warmupTime")?.InnerText);
                        verb.MuzzleFlashScale = Convert.ToDouble(node.SelectSingleNode("muzzleFlashScale")?.InnerText);
                        verb.DefaultProjectileDefName = node.SelectSingleNode("defaultProjectile")?.InnerText;
                        vanillaCompatWeapon.Verbs.Add(verb);
                    }

                    // 무기의 근접 공격 관련 정보 추출
                    vanillaCompatWeapon.MeleeTools = new List<VanillaCompatTool>();

                    foreach (XmlNode node in weaponDefs[nodeIndex].SelectNodes("tools/li"))
                    {
                        VanillaCompatTool tool = new VanillaCompatTool();

                        tool.Label = node.SelectSingleNode("label")?.InnerText;

                        tool.Capacities = new List<string>();
                        foreach (XmlNode node_capacities in node.SelectNodes("li"))
                        {
                            tool.Capacities.Add(node_capacities?.InnerText);
                        }

                        tool.Power = Convert.ToDouble(node.SelectSingleNode("power")?.InnerText);
                        tool.CooldownTime = Convert.ToDouble(node.SelectSingleNode("cooldownTime")?.InnerText);
                        vanillaCompatWeapon.MeleeTools.Add(tool);
                    }

                    if (vanillaCompatWeapon.Verbs.IsNullOrEmpty() && vanillaCompatWeapon.MeleeTools.IsNullOrEmpty())
                    {
                        continue;
                    }

                    weapons.Add(vanillaCompatWeapon);
                }

                return weapons;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on Handling Vanilla Weapon Data. Please Report to Developer.\r\n{ex.Message}");

                return null;
            }

            return null;
            // 로드된 XML 문서에서 각 ThingDef 불러오기
        }

        public static List<VanillaCompatProjectile> GetVanillaProjectiles(XmlDocument xml, List<VanillaCompatWeapon> weapons)
        {
            try
            {
                List<VanillaCompatProjectile> projectiles = new List<VanillaCompatProjectile>();

                XmlNodeList xmlNodeList = xml.SelectNodes("/Defs/ThingDef");

                if (xmlNodeList.IsNullOrEmpty())
                {
                    return null;
                }

                // 발사체 목록 생성
                for (int nodeIndex = 0; nodeIndex < xmlNodeList.Count; ++nodeIndex)
                {
                    VanillaCompatProjectile projectile = new VanillaCompatProjectile();

                    projectile.DefName = xmlNodeList[nodeIndex].SelectSingleNode("defName")?.InnerText;
                    projectile.Label = xmlNodeList[nodeIndex].SelectSingleNode("label")?.InnerText;
                    projectile.Speed = Convert.ToDouble(xmlNodeList[nodeIndex].SelectSingleNode("projectile/speed")?.InnerText);
                    projectile.DamageDef = xmlNodeList[nodeIndex].SelectSingleNode("projectile/damageDef")?.InnerText;
                    projectile.DamageAmountBase = Convert.ToDouble(xmlNodeList[nodeIndex].SelectSingleNode("projectile/damageAmountBase")?.InnerText);
                    projectile.StoppingPower = Convert.ToDouble(xmlNodeList[nodeIndex].SelectSingleNode("projectile/stoppingPower")?.InnerText);
                    projectile.Graphic = new VanillaCompatGraphicData();
                    projectile.Graphic.TexturePath = xmlNodeList[nodeIndex].SelectSingleNode("graphicData/texPath")?.InnerText;

                    projectiles.Add(projectile);
                }

                for (int weaponIndex = 0; weaponIndex < weapons.Count; ++weaponIndex)
                {
                    if (weapons[weaponIndex].Verbs.IsNullOrEmpty())
                    {
                        continue;
                    }
                    if (weapons[weaponIndex].Verbs[0].DefaultProjectileDefName == null)
                    {
                        continue;
                    }

                    foreach (VanillaCompatVerb verb in weapons[weaponIndex].Verbs)
                    {
                        verb.Projectile = projectiles.Find(projectiles => projectiles.DefName == verb.DefaultProjectileDefName);
                    }
                }

                return projectiles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on Handling Vanilla Projectile Data. Please Report to Developer.\r\n{ex.Message}");

                return null;
            }
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
