using System;
using UnityEngine;

namespace GameLogic.Effects
{
    public class Blink : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Color state1Color;
        [SerializeField] private Color state2Color;
        [SerializeField] private float time;

        private float timeout;
        private bool state;
        private bool enable;

        private void Update()
        {
            if (enable)
                BlinkTimer();
        }

        private void BlinkTimer()
        {
            if (timeout > 0)
            {
                timeout -= Time.deltaTime;
            }
            else
            {
                timeout = time;
                state = !state;
                ApplyBlink();
            }
        }

        private void ApplyBlink()
        {
            spriteRenderer.color = state ? state2Color : state1Color;
        }

        public void Off()
        {
            if (!enable) return;
            enable = false;
            state = false;
            ApplyBlink();
        }

        public void On()
        {
            if (enable) return;
            timeout = 0;
            enable = true;
        }
    }
}