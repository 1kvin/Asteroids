using GameLogic.Input;
using UnityEngine;

namespace GameLogic.PlayerBeh
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private AnimationCurve increaseSpeedAnimationCurve;
        [SerializeField] private float maxEngineSpeed;
        [SerializeField] private float rotateSpeed;
        [SerializeField] private float maxEngineRunTime;

        private IPlayerInput playerInput;
        private Player player;
        private bool isInit;
        private float engineEnableTime;
        private bool engineStatus;

        public void Init(Player player, IPlayerInput playerInput)
        {
            this.playerInput = playerInput;
            this.player = player;
            isInit = true;
        }

        public void Update()
        {
            if (!isInit) return;

            if (playerInput.IsStartMove())
            {
                engineStatus = true;
            }

            if (playerInput.IsStopMove())
            {
                engineStatus = false;
            }

            if (playerInput.IsRotateLeftMove())
            {
                player.Rotation += Time.deltaTime * 180 * rotateSpeed;
            }

            if (playerInput.IsRotateRightMove())
            {
                player.Rotation -= Time.deltaTime * 180 * rotateSpeed;
            }

            switch (engineStatus)
            {
                case false when engineEnableTime >= 0:
                    engineEnableTime -= Time.deltaTime;
                    break;
                case true when engineEnableTime <= maxEngineRunTime:
                    engineEnableTime += Time.deltaTime;
                    break;
            }

            player.Speed = increaseSpeedAnimationCurve.Evaluate(engineEnableTime / maxEngineRunTime) * maxEngineSpeed;
        }
    }
}