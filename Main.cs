using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Il2CppAssets.Scripts.Unity.Scenes;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Powers;
using Il2CppAssets.Scripts.Models.Profile;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Upgrades;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using Il2CppAssets.Scripts.Unity.UI_New.InGame.StoreMenu;
using Il2CppAssets.Scripts.Unity.UI_New.Upgrade;
using Il2CppAssets.Scripts.Utils;
using Harmony;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

using Il2CppInterop.Runtime; 
using Il2CppInterop.Runtime.InteropTypes; 
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using System.Net;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;

using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppAssets.Scripts.Unity.UI_New.Main.MonkeySelect;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Unity.Towers.Behaviors;
using Il2CppAssets.Scripts.Simulation.Towers.Behaviors;
using Il2CppAssets.Scripts.Unity.Towers;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.Towers.Projectiles;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2CppAssets.Scripts.Unity.Towers.Weapons;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation.Towers.Filters;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem.Collections;
using Il2CppAssets.Scripts.Models.Effects;
using UnityEngine.UIElements;

[assembly: MelonInfo(typeof(hackertower.Main), hackertower.ModHelperData.Name, hackertower.ModHelperData.Version, hackertower.ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace hackertower
{

    class Main : BloonsMod
    {
        //https://github.com/gurrenm3/BloonsTD6-Mod-Helper/releases
        public static int spikeWep = 0;
        public static int mortarWep = 0;
        public class hackertower : ModTower
        {
            public override string Name => "hackertower";
            public override string DisplayName => "hackertower";
            public override string Description => "Uses nanotechnology for remote attacks and earn cash by hacking into systems.";
            public override string BaseTower => "MortarMonkey";
            public override string Icon => "hackertower_Icon";
            public override string Portrait => "hackertower_Portrait";
            public override int Cost => 1500;
            public override int TopPathUpgrades => 4;
            public override int MiddlePathUpgrades => 4;
            public override int BottomPathUpgrades => 4;
            public override Il2CppAssets.Scripts.Models.TowerSets.TowerSet TowerSet => Il2CppAssets.Scripts.Models.TowerSets.TowerSet.Support;
            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {

                //towerModel.display = new PrefabReference() { guidRef = "4ead8cc58d460544790b7d1b09d37a66" };
                //towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "4ead8cc58d460544790b7d1b09d37a66" };
                towerModel.display = new PrefabReference() { guidRef = "4ead8cc58d460544790b7d1b09d37a66" };
                towerModel.GetBehavior<DisplayModel>().display = new PrefabReference() { guidRef = "4ead8cc58d460544790b7d1b09d37a66" };
                towerModel.range = 40.0f;

                //AttackModel attackModelll = ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("EngineerMonkey", 1, 0, 0))[1]);
                //attackModelll.GetBehavior<CreateTowerModel>().tower.baseId = "Gadget";

                //PrefabReference dsp = new() { guidRef = "f786dd2ad0e3e8649a8ff0ac9f8cc6fb" };
                //PrefabReference dsp2 = new() { guidRef = "d053160180f53da43be4f9972ee1497a" };
                PrefabReference dsp3 = new() { guidRef = "77503c27ee86922409f6383b5b264982" };

                //var bhv2 = new TargetSelectedPointModel("TargetSelectedPointModel_", true, false, dsp, 1.0f, "", false, false, dsp2, true, null, true);
                var bhv3 = new PerRoundCashBonusTowerModel("", 150.0f, 0.0f, 1.0f, dsp3, false);
                //var bhv3 = new TargetPointerModel("", true, false, "", false);
                //var bhv4 = towerModel.GetBehavior<TargetSelectedPointModel>();
                //attackModelll.AddBehavior(bhv2);
                towerModel.GetAttackModel(0).AddBehavior(bhv3);

                //attackModelll.targetProvider = bhv2;

                //attackModelll.targetProvider = bhv4;

                //towerModel.RemoveBehavior<ProjectileModel>();


                //PrefabReference dsp5 = new() { guidRef = "eaea79971760c5044ba962f0f1a196f8" };
                //var bhv3 = Game.instance.model.get//ModelExt.Duplicate<Behaviour>(TowerModelExt.)
                
                Il2CppReferenceArray<WeaponBehaviorModel> bhvs = TowerModelExt.GetAttackModels(Game.instance.model.GetTower("EngineerMonkey", 1, 0, 0))[1].weapons[0].behaviors.ToArray<WeaponBehaviorModel>();
                ProjectileModel proM = ModelExt.Duplicate<ProjectileModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("EngineerMonkey", 1, 0, 0))[1].weapons[0].GetDescendant<ProjectileModel>());
                //ProjectileModel proM = new ProjectileModel(dsp5, "Projectile", 2.0f, 0.0f, 1.0f, 0.0f,   )
                EmissionModel emSS = ModelExt.Duplicate<EmissionModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("EngineerMonkey", 1, 0, 0))[1].weapons[0].GetDescendant<EmissionModel>());
                WeaponModel weM = new("WeaponModel_Weapon", 2, 10.0f, proM, -1.11f, 13.49f, 10.7f, 0.0f, false, false, emSS, bhvs, false, false, 0.0f, false, false);
                //attackModelll.RemoveWeapon(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("EngineerMonkey", 1, 0, 0))[1].weapons[0]);
                //attackModelll.AddWeapon(weM);

                //attackModelll.weapons[0] = ModelExt.Duplicate<WeaponModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("MortarMonkey", 0, 0, 0))[0].weapons[0]);
                //attackModelll.weapons[0].SetProjectile(proM);
                //attackModelll.weapons[0] = weM;

                //Il2CppAssets.Scripts.Simulation.Towers.Weapons.Weapon weapon = new WeaponModel(,)
                //towerModel.AddBehavior<AttackModel>(attackModelll);
                towerModel.GetAttackModel(0).weapons[0] = weM;
                //var randP = new RandomPositionModel("randomModel", 8.0f, 40.0f, 6.0f, false, 6.0f, true, false, "Land", true, false, 43.0f, "Support");
                //towerModel.GetAttackModel(0).RemoveBehavior<TargetSelectedPointModel>();
                //towerModel.GetAttackModel(0).AddBehavior(randP);

                //WeaponModel wpM = ModelExt.Duplicate<WeaponModel>(TowerModelExt.GetWeapon(towerModel));    

                //var wpn2 = new WeaponModel(null, 1, 1, null, 0, 0, 0, 0.2f, false, false, null, null, true, false, 0, false, false);
                //towerModel.

            }

            public class SoftwareCracking : ModUpgrade<hackertower>
            {
                public override string Name => "SoftwareCracking";
                public override string DisplayName => "Software Cracking";
                public override string Description => "Selling unlicensed software for more profit.";
                public override int Cost => 700;
                public override int Path => TOP;
                public override int Tier => 1;
                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    AttackModel attackModel = towerModel.GetBehavior<AttackModel>();
                    attackModel.GetBehavior<PerRoundCashBonusTowerModel>().cashPerRound = 250.0f;
                }
                public override string Icon => "SoftwareCracking_Icon";
            }

            public class Analyze : ModUpgrade<hackertower>
            {
                public override string Name => "Analyze";
                public override string DisplayName => "Analyze";
                public override string Description => "Analyzing nearby balloons, allows all Monkeys in the radius to target Camo Bloons.";
                public override int Cost => 2000;
                public override int Path => TOP;
                public override int Tier => 2;
                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    var bhv = new VisibilitySupportModel("VisibilitySupportModel_Support_", true, "Village:Visibility", false, null, "RadarScannerBuff", "BuffIconHacker3xx");

                    //bhv.isCustomRadius = true;
                    //bhv.customRadius = 50.0f;
                    //bhv.appliesToOwningTower = true;
                    towerModel.AddBehavior(bhv);
                    towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
                }
                public override string Icon => "Analyze_Icon";
            }

            public class HackerUnion : ModUpgrade<hackertower>
            {
                public override string Name => "HackerUnion";
                public override string DisplayName => "Hacker Union";
                public override string Description => "Other hackers that placed near this tower will get %25 discount in price and below tier 3 upgrades. Can be stacked 3 times.";
                public override int Cost => 4000;
                public override int Path => TOP;
                public override int Tier => 3;
                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    var bhv = new DiscountZoneModel("DiscountZoneModel_DiscountZone", 0.25f, 3, "DiscountZone", "Hacker", false, 2, "HackerUnionBuff", "BuffIconHacker2xx", false);
                    towerModel.AddBehavior(bhv);
                }
                public override string Icon => "HackerUnion_Icon";
            }


            public class VulnerabilityTest : ModUpgrade<hackertower>
            {
                public override string Name => "VulnerabilityTest";
                public override string DisplayName => "Vulnerability Test";
                public override string Description => "Going one step further, Hacker runs vulnerability tests on nearby targets, Monkeys in Hacker's radius can damage all targets" +
                    " + they make 1.5 times more damage and cash.";
                public override int Cost => 10000;
                public override int Path => TOP;
                public override int Tier => 4;
                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    var bhv = new DamageTypeSupportModel("DamageTypeSupportModel_Support_", true, "Village:DamageType", 0, null, "MibBuff", "BuffIconHacker4xx");
                    var bhv2 = new SupportRemoveFilterOutTagModel("SupportRemoveFilterOutTagModel_Support_", "Village:DdtDamageModifier", "MibMutator", null, false, false, -1.0f, "MibBuff", "BuffIconHacker4xx");
                    var bhv3 = new DamageSupportModel("asd", true, 0.5f, "asdd", null, false, false, -1.0f);
                    var bhv4 = Game.instance.model.GetTowerFromId("MonkeyVillage-004").Duplicate<TowerModel>().GetBehavior<MonkeyCityIncomeSupportModel>();
                    bhv4.incomeModifier = 1.5f;
                    //bhv.isCustomRadius = true;
                    //bhv.customRadius = 50.0f;
                    //bhv.appliesToOwningTower = true;
                    towerModel.AddBehavior(bhv);
                    towerModel.AddBehavior(bhv2);
                    towerModel.AddBehavior(bhv3);
                    towerModel.AddBehavior(bhv4);
                }
                public override string Icon => "VulnerabilityTest_Icon";
            }

            public class BallisticGadgets : ModUpgrade<hackertower>
            {
                public override string Name => "BallisticGadgets";
                public override string DisplayName => "Ballistic Gadgets";
                public override string Description => "Gadgets gets upgraded to attack faster.";
                public override int Cost => 550;
                public override int Path => MIDDLE;
                public override int Tier => 1;
                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    AttackModel attackModel = towerModel.GetBehavior<AttackModel>().weapons[0].projectile.GetBehavior<CreateTowerModel>().tower.GetBehavior<AttackModel>();
                    attackModel.weapons[0].rate = 0.80f;
                }
                public override string Icon => "BallisticGadgets_Icon";
            }

            public class ProhibitedZone : ModUpgrade<hackertower>
            {
                public override string Name => "ProhibitedZone";
                public override string DisplayName => "Prohibited Zone";
                public override string Description => "Hacker builds spike traps under his pocket towers.";
                public override int Cost => 2000;
                public override int Path => MIDDLE;
                public override int Tier => 2;
                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    towerModel.GetBehavior<AttackModel>().AddWeapon(ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("SpikeFactory", 0, 0, 0))[0]).weapons[0]);
                    towerModel.GetBehavior<AttackModel>().weapons[towerModel.GetBehavior<AttackModel>().weapons.Count-1].rate = 10.0f;
                    towerModel.GetBehavior<AttackModel>().weapons[towerModel.GetBehavior<AttackModel>().weapons.Count - 1].projectile.scale = 2.0f;
                    towerModel.GetBehavior<AttackModel>().weapons[towerModel.GetBehavior<AttackModel>().weapons.Count - 1].projectile.radius = 30.0f;
                    towerModel.GetBehavior<AttackModel>().weapons[towerModel.GetBehavior<AttackModel>().weapons.Count - 1].projectile.pierce = 8;
                    spikeWep = towerModel.GetBehavior<AttackModel>().weapons.Count - 1;
                    //var bhv = new TargetTrackModel("TargetTrackModel_", true, false, 3.0f, false);
                    //towerModel.GetBehavior<AttackModel>().AddBehavior(bhv);
                    //AttackModel atm = ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("SpikeFactory", 0, 0, 0))[0]);
                    //atm.name = "AttackModel_SpikeTower";
                    //atm.weapons[0].animation = 3;
                    //towerModel.RemoveBehavior<AttackModel>();
                    //towerModel.AddBehavior<AttackModel>(atm);
                }
                public override string Icon => "ProhibitedZone_Icon";
            }

            public class Overheat : ModUpgrade<hackertower>
            {
                public override string Name => "Overheat";
                public override string DisplayName => "Overheat";
                public override string Description => "Gadgets starts to overheat, causing more damage to their surroundings.";
                public override int Cost => 4000;
                public override int Path => MIDDLE;
                public override int Tier => 3;
                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    var bhv = new DamageModel("DamageModel_Projectile_", 2.0f, 0.0f, true, false, true, (Il2Cpp.BloonProperties)17, (Il2Cpp.BloonProperties)17, false);
                    towerModel.GetBehavior<AttackModel>().weapons[0].projectile.behaviors[0] = bhv;
                    towerModel.GetBehavior<AttackModel>().weapons[spikeWep] = ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("SpikeFactory", 2, 0, 0))[0]).weapons[0];
                    towerModel.GetBehavior<AttackModel>().weapons[spikeWep].projectile.scale = 2.0f;
                    towerModel.GetBehavior<AttackModel>().weapons[spikeWep].projectile.radius = 30.0f;
                    towerModel.GetBehavior<AttackModel>().weapons[spikeWep].projectile.pierce = 8;
                    towerModel.GetBehavior<AttackModel>().weapons[spikeWep].rate = 7.0f;
                }

                public override string Icon => "Overheat_Icon";
            }

            public class GoingAllOut : ModUpgrade<hackertower>
            {
                public override string Name => "GoingAllOut";
                public override string DisplayName => "Going All Out!";
                public override string Description => "Throws spiky bombs instead of spikes that will explode after certain number of contacts";
                public override int Cost => 20000;
                public override int Path => MIDDLE;
                public override int Tier => 4;
                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    towerModel.GetBehavior<AttackModel>().weapons[spikeWep] = ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("SpikeFactory", 4, 0, 0))[0]).weapons[0];
                    towerModel.GetBehavior<AttackModel>().weapons[spikeWep].projectile.scale = 2.0f;
                    towerModel.GetBehavior<AttackModel>().weapons[spikeWep].projectile.radius = 30.0f;
                    towerModel.GetBehavior<AttackModel>().weapons[spikeWep].projectile.pierce = 7;
                    towerModel.GetBehavior<AttackModel>().weapons[spikeWep].rate = 8.0f;
                }

                public override string Icon => "GoingAllOut_Icon";
            }

            public class AirStrike : ModUpgrade<hackertower>
            {
                public override string Name => "AirStrike";
                public override string DisplayName => "Air Strike";
                public override string Description => "Manipulates government resources to call an air strike on the target point occasionally.";
                public override int Cost => 1100;
                public override int Path => BOTTOM;
                public override int Tier => 1;
                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    towerModel.GetBehavior<AttackModel>().AddWeapon(ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("MortarMonkey", 1, 0, 0))[0]).weapons[0]);
                    towerModel.GetBehavior<AttackModel>().weapons[towerModel.GetBehavior<AttackModel>().weapons.Count - 1].rate = 3.0f;
                    mortarWep = towerModel.GetBehavior<AttackModel>().weapons.Count - 1;
                    //attackModel.targetProvider = towerModel.GetBehavior<AttackModel>().GetBehavior<TargetSelectedPointModel>();
                    //towerModel.AddBehavior(attackModel);
                }
                public override string Icon => "AirStrike_Icon";
                //public override string Portrait => "AirStrike_Portrait";
            }

            public class Emp : ModUpgrade<hackertower>
            {
                public override string Name => "Emp";
                public override string DisplayName => "Emp";
                public override string Description => "Calls in an Emp bomber instead, explosion will create a shockwave that stuns bloons in a wide area.";
                public override int Cost => 5000;
                public override int Path => BOTTOM;
                public override int Tier => 2;
                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    /*towerModel.GetBehavior<AttackModel>().weapons[mortarWep] = ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("MortarMonkey", 3, 0, 0))[0]).weapons[0];
                    
                    
                    var slow = atm.weapons[0].GetDescendant<SlowModel>().Duplicate();
                    slow.Lifespan = 3.0f; */


                    AttackModel atm = towerModel.GetBehavior<AttackModel>();
                    AttackModel atm2 = Game.instance.model.GetTowerFromId("MortarMonkey-300").Duplicate<TowerModel>().GetAttackModel();
                    var bhv3 = atm2.weapons[0].projectile.GetBehaviors<CreateProjectileOnExhaustFractionModel>()[1];

                    if (bhv3!= null)
                     {
                        bhv3.projectile.GetBehavior<SlowModel>().lifespan = 5.0f;
                        bhv3.projectile.GetBehavior<SlowModel>().Lifespan = 5.0f;
                     }

                     
                    atm.weapons[0].projectile.AddBehavior(bhv3); 

                    atm.weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.radius = 100.0f;


                    towerModel.GetBehavior<AttackModel>().weapons[mortarWep].rate = 10.0f;
                    
                }

                public override string Icon => "Emp_Icon";
            }

            public class PredatorArmada : ModUpgrade<hackertower>
            {
                public override string Name => "PredatorArmada";
                public override string DisplayName => "Predator Armada";
                public override string Description => "Takes over an army of predator jets, faster explosions and more damage.";
                public override int Cost => 30000;
                public override int Path => BOTTOM;
                public override int Tier => 3;

                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    towerModel.GetBehavior<AttackModel>().weapons[mortarWep] = ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("MortarMonkey", 2, 4, 0))[0]).weapons[0];
                    towerModel.GetBehavior<AttackModel>().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.radius = 50.0f;
                    towerModel.GetBehavior<AttackModel>().weapons[mortarWep].rate = 0.66f;
                }

                public override string Icon => "PredatorArmada_Icon";
            }

            public class HydrogenBomb : ModUpgrade<hackertower>
            {
                public override string Name => "HydrogenBomb";
                public override string DisplayName => "Hydrogen Bomb";
                public override string Description => "Driven by anger, every 60 seconds hacker will call an atomic bomber, explosion will be catastrophic.";
                public override int Cost => 100000;
                public override int Path => BOTTOM;
                public override int Tier => 4;
                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    AttackModel atm = towerModel.GetBehavior<AttackModel>();
                    //atm.AddWeapon(ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("MortarMonkey", 1, 0, 0))[0]).weapons[0]);
                    //int i = ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("MonkeyAce", 0, 5, 0))[0]).weapons.Length;
                    //atm.AddWeapon(ModelExt.Duplicate<AttackModel>(TowerModelExt.GetAttackModels(Game.instance.model.GetTower("MonkeyAce", 0, 5, 0))[0]).weapons[i-1]);

                    
                    AbilityModel am = ModelExt.Duplicate<AbilityModel>(TowerModelExt.GetAbility(Game.instance.model.GetTower("MonkeyAce", 0, 5, 0)));
                    WeaponModel wp = am.GetBehavior<ActivateAttackModel>().GetDescendant<WeaponModel>().Duplicate();
                    atm.AddWeapon(wp);
                    atm.weapons[atm.weapons.Length - 1].projectile.SetDisplay(new PrefabReference("6f4aa8eecdb528144b69efee775c64f2"));
                    atm.weapons[atm.weapons.Length - 1].rate = 60.0f;
                    //atm.weapons[atm.weapons.Length - 1].animation = 1;
                    atm.weapons[atm.weapons.Length - 1].animationOffset = 3.5f;
                    atm.weapons[atm.weapons.Length - 1].projectile.GetBehavior<AgeModel>().Lifespan = 3.5f;
                    //atm.weapons[atm.weapons.Length - 1].useAttackPosition = true; 

                    /*
                    AbilityModel am = ModelExt.Duplicate<AbilityModel>(TowerModelExt.GetAbility(Game.instance.model.GetTower("MonkeyAce", 0, 5, 0)));

                    Il2CppReferenceArray<WeaponBehaviorModel> bhvs = am.GetBehavior<ActivateAttackModel>().GetDescendant<WeaponModel>().behaviors.ToArray<WeaponBehaviorModel>();
                    ProjectileModel proM = ModelExt.Duplicate<ProjectileModel>(am.GetBehavior<ActivateAttackModel>().GetDescendant<WeaponModel>().GetDescendant<ProjectileModel>());
                    EmissionModel emSS = ModelExt.Duplicate<EmissionModel>(am.GetBehavior<ActivateAttackModel>().GetDescendant<WeaponModel>().GetDescendant<EmissionModel>());
                    WeaponModel weM = new("WeaponModel_Weapon", -1, 30.0f, proM, 0.0f, 0.0f, 0.0f, 3.5f, true, false, emSS, bhvs, false, false, 0.0f, false, false);
                    atm.AddWeapon(weM);
                    atm.weapons[atm.weapons.Length - 1].projectile.GetBehavior<AgeModel>().Lifespan = 3.5f;
                    atm.weapons[atm.weapons.Length - 1].projectile.SetDisplay(new PrefabReference("6f4aa8eecdb528144b69efee775c64f2")); */
                }

                public override string Icon => "HydrogenBomb_Icon";
            }
        }
            
    }
}
