using UnityEngine;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using DaggerfallWorkshop.Game.Utility.ModSupport.ModSettings;
using DaggerfallWorkshop.Game.UserInterfaceWindows;
using DaggerfallWorkshop.Game.MagicAndEffects;
using DaggerfallWorkshop.Game.MagicAndEffects.MagicEffects;
using DaggerfallWorkshop.Game.Formulas;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallConnect;
using DaggerfallConnect.Arena2;
using System;
using System.Collections.Generic;
using System.Linq;
using DaggerfallWorkshop.Game.Serialization;
using DaggerfallWorkshop.Game.Utility;

namespace UnleveledSpellsMod
{
    public class UnleveledSpells : MonoBehaviour
    {
        private static Mod mod;
        private static UnleveledSpells instance;
        public static UnleveledSpells Instance { get { return instance; } }

        private UnleveledMagicRegeneration magicRegen;
        private bool unleveledOpenAndLock;

        private readonly Dictionary<string, EffectCosts> durationCostOverride = new Dictionary<string, EffectCosts>();
        private readonly Dictionary<string, EffectCosts> chanceCostOverride = new Dictionary<string, EffectCosts>();
        private readonly Dictionary<string, EffectCosts> magnitudeCostOverride = new Dictionary<string, EffectCosts>();
        private readonly Dictionary<string, float> factorOverride = new Dictionary<string, float>();

        private readonly HashSet<string> suppressedOverrides = new HashSet<string>();

        private readonly Dictionary<string, int> maxMagnitudeOverride = new Dictionary<string, int>();

        private EntityEffectBroker.OnNewMagicRoundEventHandler warningDelegate;

        const string Core = "Core";
        const string MagicRegenSection = "MagicRegen";

        #region Properties
        public Dictionary<string, int> MaxMagnitudeOverride { get { return maxMagnitudeOverride; } }

        public bool UnleveledOpenAndLock { get { return unleveledOpenAndLock; } }
        #endregion

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

            StateManager.OnStartNewGame += OnGameStarted;
            StartGameBehaviour.OnStartGame += OnNewGameStarted;

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

            instance.unleveledOpenAndLock = modSettings.GetBool(Core, "UnleveledOpenAndLock");
            if (instance.unleveledOpenAndLock)
            {
                instance.maxMagnitudeOverride.Add(Lock.EffectKey, 20);
                instance.maxMagnitudeOverride.Add(Open.EffectKey, 20);

                GameManager.Instance.EntityEffectBroker.RegisterEffectTemplate(new UnleveledOpen(), true);
                GameManager.Instance.EntityEffectBroker.RegisterEffectTemplate(new UnleveledLock(), true);

                instance.suppressedOverrides.Add(Lock.EffectKey);
                instance.suppressedOverrides.Add(Open.EffectKey);

                if(GameManager.Instance.StateManager.GameInProgress)
                {
                    AdjustOpenLockSpells();
                }
            }
            else
            {
                instance.maxMagnitudeOverride.Remove(Lock.EffectKey);
                instance.maxMagnitudeOverride.Remove(Open.EffectKey);

                GameManager.Instance.EntityEffectBroker.RegisterEffectTemplate(new Open(), true);
                GameManager.Instance.EntityEffectBroker.RegisterEffectTemplate(new Lock(), true);

                instance.suppressedOverrides.Remove(Lock.EffectKey);
                instance.suppressedOverrides.Remove(Open.EffectKey);

                if (GameManager.Instance.StateManager.GameInProgress)
                {
                    AdjustOpenLockSpells();
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

                // If all the tokens are empty, don't set override
                if (tokens.Skip(1).All(token => string.IsNullOrEmpty(token)))
                    continue;

                // Duration override
                if (tokens.Length >= 4 && !string.IsNullOrEmpty(tokens[1]))
                {
                    EffectCosts effectCosts = new EffectCosts();
                    effectCosts.CostA = float.Parse(tokens[1]);

                    if (float.TryParse(tokens[2], out float costB))
                    {
                        effectCosts.CostB = costB;
                    }

                    if (float.TryParse(tokens[3], out float offsetGold))
                    {
                        effectCosts.OffsetGold = offsetGold;
                    }

                    durationCostOverride.Add(key, effectCosts);
                }

                // Chance override
                if (tokens.Length >= 7 && !string.IsNullOrEmpty(tokens[4]))
                {
                    EffectCosts effectCosts = new EffectCosts();
                    effectCosts.CostA = float.Parse(tokens[4]);

                    if (float.TryParse(tokens[5], out float costB))
                    {
                        effectCosts.CostB = costB;
                    }

                    if (float.TryParse(tokens[6], out float offsetGold))
                    {
                        effectCosts.OffsetGold = offsetGold;
                    }

                    chanceCostOverride.Add(key, effectCosts);
                }

                // Magnitude override
                if (tokens.Length >= 10 && !string.IsNullOrEmpty(tokens[7]))
                {
                    EffectCosts effectCosts = new EffectCosts();
                    effectCosts.CostA = float.Parse(tokens[7]);

                    if (float.TryParse(tokens[8], out float costB))
                    {
                        effectCosts.CostB = costB;
                    }

                    if (float.TryParse(tokens[9], out float offsetGold))
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
            if (!suppressedOverrides.Contains(effect.Key) && factorOverride.TryGetValue(effect.Key, out float factor))
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
                if (!suppressedOverrides.Contains(effect.Key) && durationCostOverride.TryGetValue(effect.Key, out EffectCosts costOverride))
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
                if (!suppressedOverrides.Contains(effect.Key) && chanceCostOverride.TryGetValue(effect.Key, out EffectCosts costOverride))
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
                if (!suppressedOverrides.Contains(effect.Key) && magnitudeCostOverride.TryGetValue(effect.Key, out EffectCosts costOverride))
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
            if (magicRegen.enabled || IsModEnabled("BasicMagicRegen"))
                return 0;

            if (player.Career.NoRegenSpellPoints)
                return 0;

            return Mathf.Max((int)Mathf.Floor(player.MaxMagicka / 8), 1);
        }

        static void OnGameStarted(object sender, EventArgs e)
        {
            AdjustOpenLockSpells();
        }

        static void AdjustOpenLockSpells()
        {
            var Player = GameManager.Instance.PlayerEntity;

            if (instance.UnleveledOpenAndLock)
            {
                for (int i = 0; i < Player.SpellbookCount(); ++i)
                {
                    Player.GetSpell(i, out EffectBundleSettings spell);
                    if (spell.Effects.Any(
                        effect =>
                             (effect.Key == Open.EffectKey || effect.Key == Lock.EffectKey)
                             && effect.Settings.MagnitudeBaseMin <= 1 && effect.Settings.MagnitudeBaseMax <= 1
                        ))
                    {
                        Player.SetSpell(i, ToUnleveledOpenAndLock(spell));
                    }
                }
            }
            else
            {
                for (int i = 0; i < Player.SpellbookCount(); ++i)
                {
                    Player.GetSpell(i, out EffectBundleSettings spell);
                    if (spell.Effects.Any(
                        effect =>
                             (effect.Key == Open.EffectKey || effect.Key == Lock.EffectKey)
                             && (effect.Settings.MagnitudeBaseMin > 1 || effect.Settings.MagnitudeBaseMax > 1)
                        ))
                    {
                        Player.SetSpell(i, ToLeveledOpenAndLock(spell));
                    }
                }
            }
        }

        static EffectBundleSettings ToUnleveledOpenAndLock(EffectBundleSettings spell)
        {
            EffectBundleSettings newBundle = new EffectBundleSettings();
            newBundle.Version = spell.Version;
            newBundle.BundleType = spell.BundleType;
            newBundle.TargetType = spell.TargetType;
            newBundle.ElementType = spell.ElementType;
            newBundle.Name = spell.Name;
            newBundle.IconIndex = spell.IconIndex;
            newBundle.Icon = spell.Icon;
            newBundle.ElementType = spell.ElementType;
            newBundle.MinimumCastingCost = spell.MinimumCastingCost;
            newBundle.NoCastingAnims = spell.NoCastingAnims;
            newBundle.Tag = spell.Tag;

            newBundle.Effects = new EffectEntry[spell.Effects.Length];
            for (int i = 0; i < newBundle.Effects.Length; ++i)
            {
                ref var originalEffect = ref spell.Effects[i];
                if (originalEffect.Key == Open.EffectKey || originalEffect.Key == Lock.EffectKey)
                {
                    float originalLevel = originalEffect.Settings.ChanceBase / 5.0f;
                    
                    ref var newEffect = ref newBundle.Effects[i];
                    newEffect.Key = originalEffect.Key;

                    // Transfer the chance values for recovery later
                    newEffect.Settings.ChanceBase = originalEffect.Settings.ChanceBase;
                    newEffect.Settings.ChancePlus = originalEffect.Settings.ChancePlus;
                    newEffect.Settings.ChancePerLevel = originalEffect.Settings.ChancePerLevel;

                    if(originalLevel < 5)
                    {
                        originalLevel = GameManager.Instance.PlayerEntity.Level;
                    }

                    if (originalLevel < 5)
                    {
                        newEffect.Settings.MagnitudeBaseMin = 3;
                        newEffect.Settings.MagnitudeBaseMax = 7;
                    }
                    else
                    {
                        newEffect.Settings.MagnitudeBaseMin = Math.Min(Mathf.RoundToInt(originalLevel) - 2, 20);
                        newEffect.Settings.MagnitudeBaseMax = Mathf.Min(Mathf.RoundToInt(originalLevel) + 2, 20);
                    }
                    newEffect.Settings.MagnitudePerLevel = 1;
                }
                else
                {
                    newBundle.Effects[i] = originalEffect;
                }
            }

            return newBundle;
        }

        static EffectBundleSettings ToLeveledOpenAndLock(EffectBundleSettings spell)
        {
            EffectBundleSettings newBundle = new EffectBundleSettings();
            newBundle.Version = spell.Version;
            newBundle.BundleType = spell.BundleType;
            newBundle.TargetType = spell.TargetType;
            newBundle.ElementType = spell.ElementType;
            newBundle.Name = spell.Name;
            newBundle.IconIndex = spell.IconIndex;
            newBundle.Icon = spell.Icon;
            newBundle.ElementType = spell.ElementType;
            newBundle.MinimumCastingCost = spell.MinimumCastingCost;
            newBundle.NoCastingAnims = spell.NoCastingAnims;
            newBundle.Tag = spell.Tag;

            newBundle.Effects = new EffectEntry[spell.Effects.Length];
            for (int i = 0; i < newBundle.Effects.Length; ++i)
            {
                ref var originalEffect = ref spell.Effects[i];
                if (originalEffect.Key == Open.EffectKey || originalEffect.Key == Lock.EffectKey)
                {
                    float originalLevel = (originalEffect.Settings.MagnitudeBaseMin + originalEffect.Settings.MagnitudeBaseMax) / 2.0f;

                    ref var newEffect = ref newBundle.Effects[i];
                    newEffect.Key = originalEffect.Key;

                    if (originalLevel < 5)
                    {
                        originalLevel = GameManager.Instance.PlayerEntity.Level;
                    }

                    // Recover the original values if available
                    if (originalEffect.Settings.ChanceBase > 1)
                    {
                        newEffect.Settings.ChanceBase = originalEffect.Settings.ChanceBase;
                    }
                    else
                    {
                        newEffect.Settings.ChanceBase = Mathf.Max(Mathf.RoundToInt(originalLevel * 5), 25);
                    }
                    newEffect.Settings.ChancePerLevel = 1;
                }
                else
                {
                    newBundle.Effects[i] = originalEffect;
                }
            }

            return newBundle;
        }

        static void OnNewGameStarted(object sender, EventArgs e)
        {
            var RRI = ModManager.Instance.GetMod("RoleplayRealism-Items");
            if (RRI == null)
                return;

            if(RRI.GetSettings().GetBool("Modules", "skillBasedStartingSpells"))
            {
                var Player = GameManager.Instance.PlayerEntity;

                for(int i = 0; i < Player.SpellbookCount(); ++i)
                {
                    Player.GetSpell(i, out EffectBundleSettings spell);
                    switch(spell.Name)
                    {
                        case "Minor Shock":
                            Player.SetSpell(i, DuplicateWithEffect(spell, new EffectSettings()
                            {
                                // 2-10 + 1-2 / Lvl = 3-12 at level 1
                                MagnitudeBaseMin = 3,
                                MagnitudeBaseMax = 12,
                            }));
                            break;

                        case "Arcane Arrow":
                            Player.SetSpell(i, DuplicateWithEffect(spell, new EffectSettings()
                            {
                                // 5-6 + 1-1 / 2 Lvl = 5-6 at level 1
                                MagnitudeBaseMin = 5,
                                MagnitudeBaseMax = 6,
                            }));
                            break;

                        case "Gentle Fall":
                            Player.SetSpell(i, DuplicateWithEffect(spell, new EffectSettings()
                            {
                                // 2 + 1 / 2 Lvl = 2 at level 1
                                DurationBase = 2,
                            }));
                            break;

                        case "Candle":
                            Player.SetSpell(i, DuplicateWithEffect(spell, new EffectSettings()
                            {
                                // 4 + 4 / Lvl = 8 at level 1
                                DurationBase = 8,
                            }));
                            break;

                        case "Knick-Knack":
                            Player.SetSpell(i, DuplicateWithEffect(spell, new EffectSettings()
                            {
                                // 4 + 1 / 2 Lvl = 4 at level 1
                                DurationBase = 4,
                            }));
                            break;

                        // "Salve Bruise" already unleveled
                        // "Smelling Salts Bruise" already unleveled

                        case "Rise":
                            Player.SetSpell(i, DuplicateWithEffect(spell, new EffectSettings()
                            {
                                // 1 + 1 / 2 Lvl = 1 at level 1
                                // Let's pretend it's level 2 then
                                DurationBase = 2,
                            }));
                            break;

                        case "Knock":
                            // Use magnitude instead of chance
                            if(instance.unleveledOpenAndLock)
                            {
                                // Give level 3 effect
                                Player.SetSpell(i, DuplicateWithEffect(spell, new EffectSettings()
                                {
                                    MagnitudeBaseMin = 1,
                                    MagnitudeBaseMax = 5,
                                }));
                            }
                            else
                            {
                                // 8% + 2% per level = 10% at level 1
                                Player.SetSpell(i, DuplicateWithEffect(spell, new EffectSettings()
                                {
                                    ChanceBase = 10,
                                }));
                            }

                            break;

                    }
                }
            }
        }

        static EffectBundleSettings DuplicateWithEffect(EffectBundleSettings spell, EffectSettings newSettings)
        {
            EffectBundleSettings newBundle = new EffectBundleSettings();
            newBundle.Name = spell.Name;
            newBundle.Version = spell.Version;
            newBundle.BundleType = spell.BundleType;
            newBundle.TargetType = spell.TargetType;
            newBundle.ElementType = spell.ElementType;
            newBundle.IconIndex = spell.IconIndex;
            newBundle.Icon = spell.Icon;

            newBundle.Effects = new EffectEntry[1];
            newBundle.Effects[0].Key = spell.Effects[0].Key;
            newBundle.Effects[0].Settings = newSettings;

            newBundle.Effects[0].Settings.DurationPerLevel = 1;
            newBundle.Effects[0].Settings.ChancePerLevel = 1;
            newBundle.Effects[0].Settings.MagnitudePerLevel = 1;

            return newBundle;
        }
    }

    
}
