using UnityEngine;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using System.Collections.Generic;
using DaggerfallWorkshop.Game.MagicAndEffects;
using DaggerfallWorkshop.Game.Formulas;
using System;
using DaggerfallWorkshop.Game.Entity;
using System.Linq;
using DaggerfallConnect;
using DaggerfallWorkshop.Game.UserInterfaceWindows;
using DaggerfallWorkshop;

namespace UnleveledSpellsMod
{
    public class UnleveledSpells : MonoBehaviour
    {
        private static Mod mod;

        private readonly Dictionary<string, EffectCosts> durationCostOverride = new Dictionary<string, EffectCosts>();
        private readonly Dictionary<string, EffectCosts> chanceCostOverride = new Dictionary<string, EffectCosts>();
        private readonly Dictionary<string, EffectCosts> magnitudeCostOverride = new Dictionary<string, EffectCosts>();
        private readonly Dictionary<string, float> factorOverride = new Dictionary<string, float>();

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;

            var go = new GameObject(mod.Title);
            go.AddComponent<UnleveledSpells>();

            mod.IsReady = true;
        }

        private void Start()
        {
            Debug.Log("Begin mod init: Unleveled Spells");

            ParseCostOverrides();

            FormulaHelper.RegisterOverride<Func<IEntityEffect, EffectSettings, DaggerfallEntity, FormulaHelper.SpellCost>>(mod, "CalculateEffectCosts", CalculateEffectCosts);

            UIWindowFactory.RegisterCustomUIWindow(UIWindowType.EffectSettingsEditor, typeof(UnleveledSpellEffectEditor));

            DaggerfallUnity.Instance.TextProvider = new UnleveledSpellsTextProvider(DaggerfallUnity.Instance.TextProvider);

            // Fix IK's Mage Light -- Inferno :)
            try
            {
                EntityEffectBroker.CustomSpellBundleOffer MageLightInferno = GameManager.Instance.EntityEffectBroker.GetCustomSpellBundleOffer("MageLightInferno-CustomOffer");
                ref EffectSettings effect = ref MageLightInferno.BundleSetttings.Effects[0].Settings;
                effect.DurationBase = 15;
                effect.DurationPlus = 0;
                effect.DurationPerLevel = 1;
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }

            EnemyEntity.OnLootSpawned += OnEnemySpawned;

            Debug.Log("Finished mod init: Unleveled Spells");
        }

        void ParseCostOverrides()
        {
            TextAsset costsFile = mod.GetAsset<TextAsset>("SpellCosts.csv");
            if (costsFile == null)
                return;

            string[] lines = costsFile.text.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines.Skip(1))
            {
                string[] tokens = line.Split(';');
                string key = tokens[0];

                // Duration override
                if (tokens.Length >= 4 && !string.IsNullOrEmpty(tokens[1]))
                {
                    EffectCosts effectCosts = new EffectCosts();
                    effectCosts.CostA = int.Parse(tokens[1]);

                    if (int.TryParse(tokens[2], out int costB))
                    {
                        effectCosts.CostB = costB;
                    }

                    if (int.TryParse(tokens[3], out int offsetGold))
                    {
                        effectCosts.OffsetGold = offsetGold;
                    }

                    durationCostOverride.Add(key, effectCosts);
                }

                // Chance override
                if (tokens.Length >= 7 && !string.IsNullOrEmpty(tokens[4]))
                {
                    EffectCosts effectCosts = new EffectCosts();
                    effectCosts.CostA = int.Parse(tokens[4]);

                    if (int.TryParse(tokens[5], out int costB))
                    {
                        effectCosts.CostB = costB;
                    }

                    if (int.TryParse(tokens[6], out int offsetGold))
                    {
                        effectCosts.OffsetGold = offsetGold;
                    }

                    chanceCostOverride.Add(key, effectCosts);
                }

                // Magnitude override
                if (tokens.Length >= 10 && !string.IsNullOrEmpty(tokens[7]))
                {
                    EffectCosts effectCosts = new EffectCosts();
                    effectCosts.CostA = int.Parse(tokens[7]);

                    if (int.TryParse(tokens[8], out int costB))
                    {
                        effectCosts.CostB = costB;
                    }

                    if (int.TryParse(tokens[9], out int offsetGold))
                    {
                        effectCosts.OffsetGold = offsetGold;
                    }

                    magnitudeCostOverride.Add(key, effectCosts);
                }

                // Formula override
                if (tokens.Length >= 11 && !string.IsNullOrEmpty(tokens[10]))
                {
                    factorOverride.Add(key, float.Parse(tokens[10]));
                }
            }
        }

        private static int GetEffectComponentCosts(
            EffectCosts costs,
            float starting,
            float increase,
            float perLevel)
        {
            //Calculate effect gold cost, spellpoint cost is calculated from gold cost after adding up for duration, chance and magnitude
            return Mathf.RoundToInt(costs.OffsetGold + costs.CostA * starting + costs.CostB * increase / perLevel);
        }

        private FormulaHelper.SpellCost CalculateEffectCosts(IEntityEffect effect, EffectSettings settings, DaggerfallEntity casterEntity)
        {
            if (factorOverride.TryGetValue(effect.Key, out float factor))
            {
                float durationFactor = 1;
                if (effect.Properties.SupportDuration)
                {
                    durationFactor = settings.DurationBase;
                }

                float chanceFactor = 1;
                if (effect.Properties.SupportChance)
                {
                    chanceFactor = Mathf.Pow(settings.ChanceBase / 100.0f, 1.28f);
                }

                float magnitudeFactor = 1;
                if (effect.Properties.SupportMagnitude)
                {
                    float magnitudeBase = (settings.MagnitudeBaseMin + settings.MagnitudeBaseMax) / 2.0f;
                    magnitudeFactor = Mathf.Pow(magnitudeBase, 1.1f);
                }

                // Get related skill
                int skillValue;
                if (casterEntity == null)
                {
                    // From player
                    skillValue = GameManager.Instance.PlayerEntity.Skills.GetLiveSkillValue((DFCareer.Skills)effect.Properties.MagicSkill);
                }
                else
                {
                    // From another entity
                    skillValue = casterEntity.Skills.GetLiveSkillValue((DFCareer.Skills)effect.Properties.MagicSkill);
                }

                float factorResult = factor * durationFactor * chanceFactor * magnitudeFactor;

                // Add gold costs together and calculate spellpoint cost from the result
                FormulaHelper.SpellCost effectCost;
                effectCost.goldCost = Mathf.RoundToInt(factorResult * 40.0f / 6.0f);
                effectCost.spellPointCost = Mathf.RoundToInt(factorResult * (60 - (Math.Min(skillValue, 100) / 2)) / 60.0f);

                return effectCost;
            }
            else
            {
                return ClassicEffectCosts(effect, settings, casterEntity);
            }
        }

        private FormulaHelper.SpellCost ClassicEffectCosts(IEntityEffect effect, EffectSettings settings, DaggerfallEntity casterEntity)
        {
            bool activeComponents = false;

            // Duration costs
            int durationGoldCost = 0;
            if (effect.Properties.SupportDuration)
            {
                EffectCosts durationCost = effect.Properties.DurationCosts;
                if (durationCostOverride.TryGetValue(effect.Key, out EffectCosts costOverride))
                {
                    durationCost = costOverride;
                }

                activeComponents = true;
                durationGoldCost = GetEffectComponentCosts(
                    durationCost,
                    settings.DurationBase,
                    settings.DurationPlus,
                    settings.DurationPerLevel);
            }

            // Chance costs
            int chanceGoldCost = 0;
            if (effect.Properties.SupportChance)
            {
                EffectCosts chanceCosts = effect.Properties.ChanceCosts;
                if (chanceCostOverride.TryGetValue(effect.Key, out EffectCosts costOverride))
                {
                    chanceCosts = costOverride;
                }

                activeComponents = true;
                chanceGoldCost = GetEffectComponentCosts(
                    chanceCosts,
                    settings.ChanceBase,
                    settings.ChancePlus,
                    settings.ChancePerLevel);
            }

            // Magnitude costs
            int magnitudeGoldCost = 0;
            if (effect.Properties.SupportMagnitude)
            {
                EffectCosts magnitudeCosts = effect.Properties.MagnitudeCosts;
                if (magnitudeCostOverride.TryGetValue(effect.Key, out EffectCosts costOverride))
                {
                    magnitudeCosts = costOverride;
                }

                activeComponents = true;
                float magnitudeBase = (settings.MagnitudeBaseMax + settings.MagnitudeBaseMin) / 2.0f;
                float magnitudePlus = (settings.MagnitudePlusMax + settings.MagnitudePlusMin) / 2.0f;
                magnitudeGoldCost = GetEffectComponentCosts(
                    magnitudeCosts,
                    magnitudeBase,
                    magnitudePlus,
                    settings.MagnitudePerLevel);
            }

            // If there are no active components (e.g. Teleport) then fudge some costs
            // This gives the same casting cost outcome as classic and supplies a reasonable gold cost
            // Note: Classic does not assign a gold cost when a zero-component effect is the only effect present, which seems like a bug
            int fudgeGoldCost = 0;
            if (!activeComponents)
                fudgeGoldCost = 240;

            // Get related skill
            int skillValue;
            if (casterEntity == null)
            {
                // From player
                skillValue = GameManager.Instance.PlayerEntity.Skills.GetLiveSkillValue((DFCareer.Skills)effect.Properties.MagicSkill);
            }
            else
            {
                // From another entity
                skillValue = casterEntity.Skills.GetLiveSkillValue((DFCareer.Skills)effect.Properties.MagicSkill);
            }

            // Add gold costs together and calculate spellpoint cost from the result
            FormulaHelper.SpellCost effectCost;
            effectCost.goldCost = durationGoldCost + chanceGoldCost + magnitudeGoldCost + fudgeGoldCost;
            effectCost.spellPointCost = Mathf.RoundToInt(effectCost.goldCost * (60 - (Math.Min(skillValue, 100) / 2)) / 400.0f);

            return effectCost;
        }

        /*
        static byte[] ImpSpells = // Level 2
        {
            0x07, // Wizard's Fire (1-15+2d4)
            0x0A, // Free Action 
            0x1D, // Toxic Cloud (1-25+2d5)
            0x2C // Chameleon
        };
        */ 

        static byte[] ImpSpells = // Level 2
        {
            0x67, // Wizard's Fire (8-18)
            0x0A, // Free Action 
            0x66, // Toxic Cloud (12-24)
            0x2C // Chameleon
        };

        static byte[] GhostSpells = // Level 11
        {
            0x22 // Wizard Rend (12-25) | (65% for 12 rounds)
        };

        static byte[] OrcShamanSpells = // Level 13
        {
            0x06, // Invisibility 
            0x07, // Wizard's Fire (14-67)
            0x16, // Spell Shield (76% for 14 rounds)
            0x19, // Fire Storm (14-85)
            0x1F // Lightning (14-80)
        };

        static byte[] WraithSpells = // Level 15
        {
            0x1C, // Far Silence (65% for 16 rounds)
            0x1F // Lightning (16-90)
        };

        static byte[] FrostDaedraSpells = // Level 17
        {
            0x10, // Ice Bolt (18-120)
            0x14 // Ice Storm (18-115)
        };

        static byte[] FireDaedraSpells = // Level 17
        {
            0x0E, // Fireball (18-120)
            0x19 // Fire Storm (18-105)
        };

        static byte[] DaedrothSpells = // Level 18
        {
            0x16, // Spell Shield (86% for 19 rounds)
            0x17, // Silence (71% for 19 rounds)
            0x1F // Lightning (19-115)
        };

        static byte[] VampireSpells = // Level 19
        {
            0x33 // Sleep (20-110 for 43 rounds)
                // Probably meant to be 0x34, Vampiric Touch
        };

        static byte[] SeducerSpells = // Level 19
        {
            0x34, // Vampiric Touch (20-110)
            0x43 // Energy Leech (96-105)
        };

        static byte[] VampireAncientSpells = // Level 20
        {
            0x08, // Shock (21-100)
            0x32 // Paralysis (65% for 23 rounds)
        };

        static byte[] DaedraLordSpells = // Level 20
        {
            0x08, // Shock (21-100)
            0x0A, // Free Action
            0x0E, // Fireball (21-141)
            0x3C, // Balyna's Antidote (100%)
            0x43 // Energy Leech (101-110)
        };

        static byte[] LichSpells = // Level 20
        {
            0x08, // Shock (21-100)
            0x0A, // Free Action
            0x0E, // Fireball (21-141)
            0x22, // Wizard Rend (21-35) | (100% for 21 rounds)
            0x3C // Balyna's Antidote (100%)
        };

        static byte[] AncientLichSpells = // Level 21
        {
            0x08, // Shock (22-104)
            0x0A, // Free Action
            0x0E, // Fireball (22-148)
            0x1D, // Toxic Cloud (22-130)
            0x1F, // Lightning (22-130)
            0x22, // Wizard Rend (22-36) | (100% for 22 rounds)
            0x3C // Balyna's Antidote (100%)
        };

        static byte[] EnemyClass1_2 =
        {
            0x10, // Ice Bolt (18-120)
            0x14 // Ice Storm (18-115)
        };

        static byte[] EnemyClass3_5 =
        {
            0x16, // Spell Shield (86% for 19 rounds)
            0x17, // Silence (71% for 19 rounds)
            0x1F // Lightning (19-115)
        };

        static byte[] EnemyClass6_8 =
        {
            0x06, // Invisibility 
            0x07, // Wizard's Fire (14-67)
            0x16, // Spell Shield (76% for 14 rounds)
            0x19, // Fire Storm (14-85)
            0x1F // Lightning (14-80)
        };

        static byte[] EnemyClass9_11 =
        {
            0x08, // Shock (21-100)
            0x32 // Paralysis (65% for 23 rounds)
        };

        static byte[] EnemyClass12_14 =
        {
            0x08, // Shock (21-100)
            0x0A, // Free Action
            0x0E, // Fireball (21-141)
            0x3C, // Balyna's Antidote (100%)
            0x43 // Energy Leech (101-110)
        };

        static byte[] EnemyClass15_17 =
        {
            0x08, // Shock (21-100)
            0x0A, // Free Action
            0x0E, // Fireball (21-141)
            0x22, // Wizard Rend (21-35) | (100% for 21 rounds)
            0x3C // Balyna's Antidote (100%)
        };

        static byte[] EnemyClass18 =
        {
            0x08, // Shock (22-104)
            0x0A, // Free Action
            0x0E, // Fireball (22-148)
            0x1D, // Toxic Cloud (22-130)
            0x1F, // Lightning (22-130)
            0x22, // Wizard Rend (22-36) | (100% for 22 rounds)
            0x3C // Balyna's Antidote (100%)
        };

        static byte[][] EnemyClassSpells =
        {
            EnemyClass1_2, // 1-2
            EnemyClass3_5, // 3-5
            EnemyClass6_8, // 6-8
            EnemyClass9_11, // 9-11
            EnemyClass12_14, // 12-14
            EnemyClass15_17, // 15-17
            EnemyClass18 // 18+
        };

        // Spider (Level 4)
        // Spider Touch (65% for 5 rounds)

        // Scorpion (Level 12)
        // Spider Touch (100% for 13 rounds)

        void OnEnemySpawned(object sender, EnemyLootSpawnedEventArgs args)
        {
            var enemyEntity = sender as EnemyEntity;
            if (enemyEntity == null)
                return;

            // Reset spells
            while (enemyEntity.SpellbookCount() > 0)
                enemyEntity.DeleteSpell(enemyEntity.SpellbookCount() - 1);

            // Assign new
            if (enemyEntity.EntityType == EntityTypes.EnemyClass && (enemyEntity.MobileEnemy.CastsMagic))
            {
                int spellListLevel = enemyEntity.Level / 3;
                if (spellListLevel > 6)
                    spellListLevel = 6;
                enemyEntity.SetEnemySpells(EnemyClassSpells[spellListLevel]);
            }
            else
            {
                if (enemyEntity.CareerIndex == (int)MonsterCareers.Imp)
                    enemyEntity.SetEnemySpells(ImpSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.Ghost)
                    enemyEntity.SetEnemySpells(GhostSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.OrcShaman)
                    enemyEntity.SetEnemySpells(OrcShamanSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.Wraith)
                    enemyEntity.SetEnemySpells(WraithSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.FrostDaedra)
                    enemyEntity.SetEnemySpells(FrostDaedraSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.FireDaedra)
                    enemyEntity.SetEnemySpells(FireDaedraSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.Daedroth)
                    enemyEntity.SetEnemySpells(DaedrothSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.Vampire)
                    enemyEntity.SetEnemySpells(VampireSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.DaedraSeducer)
                    enemyEntity.SetEnemySpells(SeducerSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.VampireAncient)
                    enemyEntity.SetEnemySpells(VampireAncientSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.DaedraLord)
                    enemyEntity.SetEnemySpells(DaedraLordSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.Lich)
                    enemyEntity.SetEnemySpells(LichSpells);
                else if (enemyEntity.CareerIndex == (int)MonsterCareers.AncientLich)
                    enemyEntity.SetEnemySpells(AncientLichSpells);
            }
        }
    }
}
