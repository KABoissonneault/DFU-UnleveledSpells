using DaggerfallConnect;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.MagicAndEffects;
using DaggerfallWorkshop.Game.MagicAndEffects.MagicEffects;

namespace UnleveledSpellsMod
{
    public class UnleveledOpen : Open
    {
        public override void SetProperties()
        {
            properties.DisableReflectiveEnumeration = true;
            properties.Key = EffectKey;
            properties.ClassicKey = MakeClassicKey(17, 255);
            properties.ShowSpellIcon = false;
            properties.SupportMagnitude = true;
            properties.AllowedTargets = EntityEffectBroker.TargetFlags_Self;
            properties.AllowedElements = EntityEffectBroker.ElementFlags_MagicOnly;
            properties.AllowedCraftingStations = MagicCraftingStations.SpellMaker;
            properties.MagicSkill = DFCareer.MagicSkills.Mysticism;
            properties.MagnitudeCosts = MakeEffectCosts(71.0f, 0);
        }

        protected override void StartWaitingForDoor()
        {
            // Output "Ready to open." if the host manager is player
            if (awakeAlert && manager.EntityBehaviour == GameManager.Instance.PlayerEntityBehaviour)
            {
                DaggerfallUI.AddHUDText(TextManager.Instance.GetLocalizedText("readyToOpen"), 1.5f);
                awakeAlert = false;
            }
        }

        /// <summary>
        /// Called by entity holding Open incumbent when they activate a door.
        /// For player this is called by PlayerActivate when opening/closing a door.
        /// Enemies cannot use Lock/Open effects at this time.
        /// This effect will automatically open door if closed when spell triggered.
        /// </summary>
        /// <param name="actionDoor">DaggerfallActionDoor activated by entity.</param>
        public override void TriggerOpenEffect(DaggerfallActionDoor actionDoor)
        {
            if (forcedRoundsRemaining == 0)
                return;

            bool activatedByPlayer = (manager.EntityBehaviour == GameManager.Instance.PlayerEntityBehaviour);

            if (actionDoor.IsLocked)
            {
                // Unlocks door to rolled magnitude
                // Skeleton's Key can open even magical locks
                if (castBySkeletonKey || actionDoor.CurrentLockValue <= GetMagnitude(caster))
                {
                    actionDoor.CurrentLockValue = 0;
                }
                else if (activatedByPlayer)
                {
                    if (actionDoor.CurrentLockValue <= settings.MagnitudeBaseMax)
                    {
                        DaggerfallUI.AddHUDText(TextManager.Instance.GetLocalizedText("lockpickingFailure"), 1.5f);
                    }
                    else
                    {
                        DaggerfallUI.AddHUDText(TextManager.Instance.GetLocalizedText("openFailed"), 1.5f);
                    }
                }
            }

            if (!actionDoor.IsLocked && actionDoor.IsClosed)
            {
                // Automatically open door if closed and unlocked
                actionDoor.ToggleDoor(activatedByPlayer);
            }

            // Expire effect once door activated
            CancelEffect();
        }

        public override bool TriggerExteriorOpenEffect(int buildingLockValue)
        {
            bool success;

            if (castBySkeletonKey || buildingLockValue <= GetMagnitude(caster))
            {
                success = true;
            }
            else
            {
                if (buildingLockValue <= settings.MagnitudeBaseMax)
                {
                    DaggerfallUI.AddHUDText(TextManager.Instance.GetLocalizedText("lockpickingFailure"), 1.5f);
                }
                else
                {
                    DaggerfallUI.AddHUDText(TextManager.Instance.GetLocalizedText("openFailed"), 1.5f);
                }

                success = false;
            }

            // Cancel effect
            CancelEffect();
            return success;
        }
    }
}
