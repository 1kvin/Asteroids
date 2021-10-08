using GameLogic.Actions;
using UnityEngine;

namespace UI.EndGame
{
    public class EndGameUI : MonoBehaviour
    {
        [SerializeField] private RestartGameAction restartGameAction;
        [SerializeField] private float lockTime;
        private float lockTimeout;
        
        private void Update()
        {
            if (lockTimeout <= 0 && Input.anyKey)
            {
                restartGameAction.RestartGame();
            }

            if (lockTimeout > 0)
            {
                lockTimeout -= Time.deltaTime;
            }
        }

        public void SetInputLock()
        {
            lockTimeout = lockTime;
        }
    }
}
