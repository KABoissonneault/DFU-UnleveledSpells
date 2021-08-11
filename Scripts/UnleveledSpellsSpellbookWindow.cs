using DaggerfallWorkshop;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Formulas;
using DaggerfallWorkshop.Game.MagicAndEffects;
using DaggerfallWorkshop.Game.UserInterface;
using DaggerfallWorkshop.Game.UserInterfaceWindows;
using DaggerfallWorkshop.Game.Utility.ModSupport;
using System;
using UnityEngine;

namespace UnleveledSpellsMod
{
    class UnleveledSpellsSpellbookWindow : DaggerfallSpellBookWindow
    {
        #region Constructors

        bool hasHotkeyBar = false;

        public UnleveledSpellsSpellbookWindow(IUserInterfaceManager uiManager, DaggerfallBaseWindow previous, bool buyMode)
            : base(uiManager, previous, buyMode)
        {
            hasHotkeyBar = ModManager.Instance.GetMod("Hotkey Bar") != null;
        }

        #endregion

        public override void Update()
        {
            base.Update();

            // Handle hotkey assignment
            if(!buyMode && spellsListBox.SelectedIndex != -1 && hasHotkeyBar)
            {
                int maxHotkeySize = 0;
                ModManager.Instance.SendModMessage("Hotkey Bar", "GetMaxHotkeyBarSize", null, (string _, object result) => { maxHotkeySize = (int)result; });

                for(int i = 1; i <= maxHotkeySize; ++i)
                {
                    if (!Enum.TryParse($"Alpha{i}", out KeyCode keyCode))
                        break;

                    if(Input.GetKeyDown(keyCode))
                    {
                        Tuple<KeyCode, int, string> args = new Tuple<KeyCode, int, string>(keyCode, spellsListBox.SelectedIndex, "Spell");
                        ModManager.Instance.SendModMessage("Hotkey Bar", "RegisterHotkey", args, (string _, object result) =>
                        {
                            string error = result as string;
                            if(!string.IsNullOrEmpty(error))
                            {
                                Debug.LogError("RegisterHotkey failed: " + error);
                            }
                        });
                    }
                }
            }
        }

        protected override void UpdateSelection()
        {
            // Update spell list scroller
            spellsListScrollBar.Reset(spellsListBox.RowsDisplayed, spellsListBox.Count, spellsListBox.ScrollIndex);
            spellsListScrollBar.TotalUnits = spellsListBox.Count;
            spellsListScrollBar.ScrollIndex = spellsListBox.ScrollIndex;

            // Get spell settings selected from player spellbook or offered spells
            EffectBundleSettings spellSettings;
            if (buyMode)
            {
                spellSettings = offeredSpells[spellsListBox.SelectedIndex];

                // Kab: change gold cost to actually reflect the formula         
                (int goldCost, int _) = FormulaHelper.CalculateTotalEffectCosts(spellSettings.Effects, spellSettings.TargetType);
                presentedCost = goldCost;

                // Presented cost is halved on Witches Festival holiday
                uint gameMinutes = DaggerfallUnity.Instance.WorldTime.DaggerfallDateTime.ToClassicDaggerfallTime();
                int holidayID = FormulaHelper.GetHolidayId(gameMinutes, 0);
                if (holidayID == (int)DaggerfallConnect.DFLocation.Holidays.Witches_Festival)
                {
                    presentedCost >>= 1;
                    if (presentedCost == 0)
                        presentedCost = 1;
                }

                spellCostLabel.Text = presentedCost.ToString();
            }
            else
            {
                // Get spell and exit if spell index not found
                if (!GameManager.Instance.PlayerEntity.GetSpell(spellsListBox.SelectedIndex, out spellSettings))
                {
                    spellNameLabel.Text = string.Empty;
                    ClearEffectLabels();
                    ShowIcons(false);
                    return;
                }
            }

            // Update spell name label
            spellNameLabel.Text = spellSettings.Name;

            // Update effect labels
            if (spellSettings.Effects != null && spellSettings.Effects.Length > 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (i < spellSettings.Effects.Length)
                        SetEffectLabels(spellSettings.Effects[i].Key, i);
                    else
                        SetEffectLabels(string.Empty, i);
                }
            }
            else
            {
                SetEffectLabels(string.Empty, 0);
                SetEffectLabels(string.Empty, 1);
                SetEffectLabels(string.Empty, 2);
            }

            // Update spell icons
            spellIconPanel.BackgroundTexture = GetSpellIcon(spellSettings.Icon);
            spellTargetIconPanel.BackgroundTexture = GetSpellTargetIcon(spellSettings.TargetType);
            spellTargetIconPanel.ToolTipText = GetTargetTypeDescription(spellSettings.TargetType);
            spellElementIconPanel.BackgroundTexture = GetSpellElementIcon(spellSettings.ElementType);
            spellElementIconPanel.ToolTipText = GetElementDescription(spellSettings.ElementType);
            ShowIcons(true);
        }
    }
}
