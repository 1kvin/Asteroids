using GameLogic.PlayerBeh;
using UnityEngine;

namespace GameLogic.Obstacles.Ufo
{
    public class UfoBehaviour : ObstacleBehaviour
    {
        private Player player;

        public void Init(Player player)
        {
            this.player = player;
        }

        protected override void UpdateActions()
        {
            GoToPlayer();
        }

        private void GoToPlayer()
        {
            Vector2 position = _transform.position;
            var direction = position - Vector2.MoveTowards(position, player.Position, Time.deltaTime);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
            Obstacle.Rotation = angle;
        }

        public override void OnHitBullet()
        {
            DestroyObstacle();
        }

        public override void OnHitLaser()
        {
            DestroyObstacle();
        }

        public override void OnHitAsteroid(ObstacleBehaviour from) { }

        public override void OnHitUfo(UfoBehaviour ufo) { }

        private void OnTriggerEnter2D(Collider2D other)
        {
            var obstacleBehaviour = other.GetComponent<ObstacleBehaviour>();
            if (obstacleBehaviour != null)
            {
                obstacleBehaviour.OnHitUfo(this);
            }
        }
    }
}