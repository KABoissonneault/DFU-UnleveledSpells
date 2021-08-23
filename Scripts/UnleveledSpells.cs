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
using DaggerfallWorkshop.Game.Utility.ModSupport.ModSettings;
using DaggerfallConnect.Arena2;

namespace UnleveledSpellsMod
{
    public class UnleveledSpells : MonoBehaviour
    {
        private static Mod mod;
        private static UnleveledSpells instance;
        public static UnleveledSpells Instance { get { return instance; } }

        private UnleveledMagicRegeneration magicRegen;

        private readonly Dictionary<string, EffectCosts> durationCostOverride = new Dictionary<string, EffectCosts>();
        private readonly Dictionary<string, EffectCosts> chanceCostOverride = new Dictionary<string, EffectCosts>();
        private readonly Dictionary<string, EffectCosts> magnitudeCostOverride = new Dictionary<string, EffectCosts>();
        private readonly Dictionary<string, float> factorOverride = new Dictionary<string, float>();

        private EntityEffectBroker.OnNewMagicRoundEventHandler warningDelegate;

        const string MagicRegenSection = "MagicRegen";

        [Invoke(StateManager.StateTypes.Start, 0)]
        public static void Init(InitParams initParams)
        {
            mod = initParams.Mod;

            var go = new GameObject(mod.Title);
            instance = go.AddComponent<UnleveledSpells>();
            instance.magicRegen = go.AddComponent<UnleveledMagicRegeneration>();

            mod.LoadSettingsCallback = LoadSettings;

            mod.IsReady = true;
        }
        
        private void Start()
        {
            Debug.Log("Begin mod init: Unleveled Spells");

            mod.LoadSettings();

            if(IsModEnabled("Skilled Spells"))
            {
                void SkilledSpellsWarning()
                {
                    TextFile.Token[] tokens = DaggerfallUnity.Instance.TextProvider.CreateTokens(TextFile.Formatting.JustifyCenter,
                        "Unleveled Spells and Skilled Spells are conflicting.",
                        "Restart Daggerfall Unity and disable Skilled Spells"
                        );
                    DaggerfallUI.AddHUDText(tokens, 5.0f);
                }

                AssignWarning(SkilledSpellsWarning);
            }

            ParseCostOverrides();

            FormulaHelper.RegisterOverride<Func<IEntityEffect, EffectSettings, DaggerfallEntity, FormulaHelper.SpellCost>>(mod, "CalculateEffectCosts", CalculateEffectCosts);
            FormulaHelper.RegisterOverride<Func<PlayerEntity, int>>(mod, "CalculateSpellPointRecoveryRate", CalculateSpellPointRecoveryRate);

            UIWindowFactory.RegisterCustomUIWindow(UIWindowType.EffectSettingsEditor, typeof(UnleveledSpellEffectEditor));
            UIWindowFactory.RegisterCustomUIWindow(UIWindowType.SpellBook, typeof(UnleveledSpellsSpellbookWindow));

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

            EnemyEntity.OnLootSpawned += UnleveledEnemySpells.OnEnemySpawned;

            Debug.Log("Finished mod init: Unleveled Spells");
        }

        private void OnDestroy()
        {
            AssignWarning(null);
        }

        private void AssignWarning(EntityEffectBroker.OnNewMagicRoundEventHandler handler)
        {
            if (warningDelegate != null)
            {
                EntityEffectBroker.OnNewMagicRound -= warningDelegate;
            }

            warningDelegate = handler;

            if (warningDelegate != null)
            {
                EntityEffectBroker.OnNewMagicRound += warningDelegate;
            }
        }

        #region Settings

        static void LoadSettings(ModSettings modSettings, ModSettingsChange change)
        {
            bool regenMagic = modSettings.GetBool(MagicRegenSection, "Enabled");
            instance.magicRegen.enabled = regenMagic;

            void MagicRegenWarn()
            {
                TextFile.Token[] tokens = DaggerfallUnity.Instance.TextProvider.CreateTokens(TextFile.Formatting.JustifyCenter,
                        "Unleveled Spells' magic regen and Basic Magic Regen are conflicting.",
                        "Disable either one in the Mod Settings"
                        );
                DaggerfallUI.AddHUDText(tokens, 5.0f);
            }

            if (regenMagic && IsModEnabled("BasicMagicRegen"))
            {
                instance.AssignWarning(MagicRegenWarn);
            }
            else
            {
                if (instance.warningDelegate == MagicRegenWarn)
                {
                    EntityEffectBroker.OnNewMagicRound -= instance.warningDelegate;
                    instance.warningDelegate = null;
                }
            }
        }

        static bool IsModEnabled(string modName)
        {
            Mod mod = ModManager.Instance.GetMod(modName);
            return mod != null && mod.Enabled;
        }
        #endregion

        #region Spell Costs
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
        #endregion

        int CalculateSpellPointRecoveryRate(PlayerEntity player)
        {
            // Disable rest recovery if using real-time magic regen
            if (magicRegen)
                return 0;

            if (player.Career.NoRegenSpellPoints)
                return 0;

            return Mathf.Max((int)Mathf.Floor(player.MaxMagicka / 8), 1);
        }
    }
}
