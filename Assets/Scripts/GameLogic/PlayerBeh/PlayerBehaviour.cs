using GameLogic.Input;
using GameLogic.Obstacles;
using GameLogic.Obstacles.Ufo;
using UnityEngine;

namespace GameLogic.PlayerBeh
{
    public class PlayerBehaviour : ObstacleBehaviour
    {
        [SerializeField] private PlayerShoot playerShoot;
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerDamage playerDamage;
 
        private Player player;
        
        public Player Init(IPlayerInput playerInput)
        {
            player = new Player(transform.position, playerShoot, playerMovement, playerDamage);
            playerMovement.Init(player, playerInput);
            playerShoot.Init(playerInput);
            playerDamage.Init(this);
            
            base.Init(player);
            return player;
        }

        public override void OnHitAsteroid(ObstacleBehaviour from)
        {
            from.DestroyObstacle();
            playerDamage.GetHit();
        }

        public override void OnHitBullet()
        {
            playerDamage.GetHit();
        }
        
        public override void OnHitUfo(UfoBehaviour ufo)
        {
            ufo.DestroyObstacle();
            playerDamage.GetHit();
        }
        
        public override void OnHitLaser() { }
    }
}