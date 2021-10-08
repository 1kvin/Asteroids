using System;
using System.Text;
using GameLogic.PlayerBeh;
using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame
{
    public class PlayerInfo : MonoBehaviour
    {
        [SerializeField] private Text infoText;

        public void UpdateText(Player player)
        {
            var sb = new StringBuilder();
            sb.Append($"Live {new string('♡', player.PlayerDamage.LiveLeft)}\n");
            sb.Append($"Laser charges: {player.PlayerShoot.LaserShots}/{player.PlayerShoot.MaxLaserShots}\n");
            sb.Append($"Laser reload: {Math.Round(player.PlayerShoot.LaserTimeout, 1)} s\n");
            sb.Append($"Position: x:{Math.Round(player.Position.x, 1)}, y:{Math.Round(player.Position.y, 1)}\n");
            sb.Append($"Rotation: {Mathf.RoundToInt(player.Rotation % 360)}°\n");
            sb.Append($"Speed: {Math.Round(player.Speed, 1)} u/s\n");

            infoText.text = sb.ToString();
        }
    }
}