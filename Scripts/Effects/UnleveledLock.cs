using DaggerfallConnect;
using DaggerfallWorkshop;
using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.MagicAndEffects;
using DaggerfallWorkshop.Game.MagicAndEffects.MagicEffects;

namespace UnleveledSpellsMod
{
    public class UnleveledLock : Lock
    {
        public override void SetProperties()
        {
            properties.DisableReflectiveEnumeration = true;
            properties.Key = EffectKey;
            properties.ClassicKey = MakeClassicKey(16, 255);
            properties.ShowSpellIcon = false;
            properties.SupportMagnitude = true;
            properties.AllowedTargets = EntityEffectBroker.TargetFlags_Self;
            properties.AllowedElements = EntityEffectBroker.ElementFlags_MagicOnly;
            properties.AllowedCraftingStations = MagicCraftingStations.SpellMaker;
            properties.MagicSkill = DFCareer.MagicSkills.Mysticism;
            properties.MagnitudeCosts = MakeEffectCosts(42.6f, 0);
        }

        protected override void StartWaitingForDoor()
        {
            // Output "Ready to lock." if the host manager is player
            if (awakeAlert && manager.EntityBehaviour == GameManager.Instance.PlayerEntityBehaviour)
            {
                DaggerfallUI.AddHUDText(TextManager.Instance.GetLocalizedText("readyToLock"), 1.5f);
                awakeAlert = false;
            }
        }

        /// <summary>
        /// Called by entity holding Lock incumbent when they activate a door.
        /// For player this is called by PlayerActivate when opening/closing a door.
        /// Enemies cannot use Lock/Open effects at this time.
        /// This effect will automatically close door if open when spell triggered.
        /// </summary>
        /// <param name="actionDoor">DaggerfallActionDoor activated by entity.</param>
        public override void TriggerLockEffect(DaggerfallActionDoor actionDoor)
        {
            if (forcedRoundsRemaining == 0)
                return;

            bool activatedByPlayer = (manager.EntityBehaviour == GameManager.Instance.PlayerEntityBehaviour);

            if (actionDoor.IsLocked)
            {
                // Door already locked
                if (activatedByPlayer)
                    DaggerfallUI.AddHUDText(TextManager.Instance.GetLocalizedText("doorAlreadyLocked"), 1.5f);
            }
            else
            {
                // Locks door to the rolled magnitude
                actionDoor.CurrentLockValue = GetMagnitude(caster);

                if (activatedByPlayer)
                    DaggerfallUI.AddHUDText(TextManager.Instance.GetLocalizedText("doorLocked"), 1.5f);
            }

            if (actionDoor.IsOpen)
            {
                // Automatically close door if open
                actionDoor.ToggleDoor(activatedByPlayer);
            }

            // Expire effect once door activated
            CancelEffect();
        }
    }
}
