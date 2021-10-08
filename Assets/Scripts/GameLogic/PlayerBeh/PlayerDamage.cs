using GameLogic.Effects;
using UnityEngine;

namespace GameLogic.PlayerBeh
{
    public class PlayerDamage : MonoBehaviour
    {
        [SerializeField] private Blink blink;
        [SerializeField] private int startLive;
        [SerializeField] private float invulnerabilityTime;
        public int LiveLeft { get; private set; }
        
        private PlayerBehaviour playerBehaviour;
        private float invulnerabilityTimeout;

        public void Init(PlayerBehaviour playerBehaviour)
        {
            this.playerBehaviour = playerBehaviour;
            LiveLeft = startLive;
        }

        private void Update()
        {
            InvulnerabilityTimer();
        }

        private void InvulnerabilityTimer()
        {
            if (invulnerabilityTimeout > 0)
            {
                invulnerabilityTimeout -= Time.deltaTime;
                blink.On();
            }
            else
            {
                blink.Off();
            }
        }
        

        public void GetHit()
        {
            if (invulnerabilityTimeout > 0)
            {
                return;
            }

            if (LiveLeft != 0)
            {
                LiveLeft--;
                invulnerabilityTimeout = invulnerabilityTime;
            }
            else
            {
                playerBehaviour.DestroyObstacle();
            }
        }
    }
}