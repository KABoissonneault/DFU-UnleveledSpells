using DaggerfallWorkshop.Game;
using DaggerfallWorkshop.Game.Entity;
using DaggerfallWorkshop.Game.MagicAndEffects;
using UnityEngine;

namespace UnleveledSpellsMod
{
    public class UnleveledMagicRegeneration : MonoBehaviour
    {
        private bool regenCooldown = false;
        private float regenBuffer = 0.0f;

        private EntityEffectBroker.OnNewMagicRoundEventHandler regenDelegate;

        private void OnDestroy()
        {
            ClearState();
        }

        private void OnEnable()
        {
            GameManager.Instance.PlayerSpellCasting.OnReleaseFrame += PlayerSpellCasting_OnReleaseFrame;
            regenDelegate = OnNewMagicRound;
            EntityEffectBroker.OnNewMagicRound += regenDelegate;

            // Reset state
            regenCooldown = false;
            regenBuffer = 0.0f;
        }

        private void OnDisable()
        {            
            ClearState();
        }

        private void ClearState()
        {
            // Player Object might not be available in this context. Only remove it if we have any player
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                var playerSpellCasting = playerObject.GetComponent<FPSSpellCasting>();
                if (playerSpellCasting != null)
                {
                    playerSpellCasting.OnReleaseFrame -= PlayerSpellCasting_OnReleaseFrame;
                }
            }
                        
            if (regenDelegate != null)
            {
                EntityEffectBroker.OnNewMagicRound -= regenDelegate;
                regenDelegate = null;
            }
        }

        private float GetRegenPerRound(DaggerfallEntity entity)
        {
            return entity.Stats.LiveWillpower / 12.0f;
        }

        void OnNewMagicRound()
        {
            PlayerEntity player = GameManager.Instance.PlayerEntity;
            if (player == null)
                return;

            if (player.Career.NoRegenSpellPoints)
                return;
            
            // Handle regeneration cooldown
            if (regenCooldown)
            {
                regenCooldown = false;
                return;
            }

            if (player.CurrentMagicka == player.MaxMagicka)
            {
                regenBuffer = 0.0f;
                return;
            }

            regenBuffer += GetRegenPerRound(player);
            int regenCount = Mathf.FloorToInt(regenBuffer);
            if (regenCount == 0)
                return;

            player.CurrentMagicka = Mathf.Min(player.MaxMagicka, player.CurrentMagicka + regenCount);
            regenBuffer -= regenCount;
        }

        void PlayerSpellCasting_OnReleaseFrame()
        {
            regenCooldown = true;
        }
    }
}
