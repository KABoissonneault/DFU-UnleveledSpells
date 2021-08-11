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
            if(spellsListBox.SelectedIndex != -1 && hasHotkeyBar)
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
    }
}
