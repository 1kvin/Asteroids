using UnityEngine;

namespace GameLogic.Input
{
    public class PlayerKeyboardAndMouseInput : IPlayerInput
    {
        public bool IsShoot()
        {
            return UnityEngine.Input.GetButton("Fire1");
        }
        
        public bool IsLaserShoot()
        {
            return UnityEngine.Input.GetButtonDown("Fire2");
        }

        public bool IsStartMove()
        {
            return UnityEngine.Input.GetKeyDown(KeyCode.W);
        }

        public bool IsStopMove()
        {
            return UnityEngine.Input.GetKeyUp(KeyCode.W);
        }

        public bool IsRotateLeftMove()
        {
            return UnityEngine.Input.GetKey(KeyCode.A);
        }

        public bool IsRotateRightMove()
        {
            return UnityEngine.Input.GetKey(KeyCode.D);
        }
    }
}