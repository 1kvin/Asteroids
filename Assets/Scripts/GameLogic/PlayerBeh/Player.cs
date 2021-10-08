using GameLogic.Obstacles;
using UnityEngine;

namespace GameLogic.PlayerBeh
{
    public class Player : Obstacle
    {
        public readonly PlayerShoot PlayerShoot;
        public readonly PlayerMovement PlayerMovement;
        public readonly PlayerDamage PlayerDamage;


        public Player(Vector3 position, PlayerShoot playerShoot, PlayerMovement playerMovement, PlayerDamage playerDamage)
            : base(position, 0.1f, 0, 0, 0)
        {
            this.PlayerShoot = playerShoot;
            this.PlayerMovement = playerMovement;
            this.PlayerDamage = playerDamage;
        }
    }
}