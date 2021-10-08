using GameLogic.Obstacles.Ufo;
using UnityEngine;

namespace GameLogic.Obstacles.Asteroid
{
    public class AsteroidBehaviour : ObstacleBehaviour
    {
        public override void OnHitBullet()
        {
            DestroyObstacle();
        }

        public override void OnHitLaser()
        {
            DestroyObstacle();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var obstacleBehaviour = other.GetComponent<ObstacleBehaviour>();
            if (obstacleBehaviour != null)
            {
                obstacleBehaviour.OnHitAsteroid(this);
            }
        }
        
        public override void OnHitAsteroid(ObstacleBehaviour from) { }
        public override void OnHitUfo(UfoBehaviour ufo) { }
    }
}