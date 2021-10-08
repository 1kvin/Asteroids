using System;
using GameLogic.Obstacles.Ufo;
using UnityEngine;

namespace GameLogic.Obstacles
{
    public abstract class ObstacleBehaviour : MonoBehaviour
    {
        [SerializeField] protected int gold;
        public Action<ObstacleBehaviour> BeforeDestroy;
        public Obstacle Obstacle { get; private set; }
        private ObstaclesScreen obstaclesScreen;

        private bool isInit;
        protected Transform _transform;
        
        public abstract void OnHitBullet();
        public abstract void OnHitLaser();
        public abstract void OnHitAsteroid(ObstacleBehaviour from);
        
        public abstract void OnHitUfo(UfoBehaviour ufo);

       
        public void Init(Vector3 position, float size, float speed, float rotation)
        {
            var obs = new Obstacle(position, size, speed, rotation, gold);
            Init(obs);
        }
        
        protected void Init(Obstacle obstacle)
        {
            _transform = transform;
            this.Obstacle = obstacle;
            obstaclesScreen = new ObstaclesScreen(obstacle, gameObject.GetComponent<Renderer>(), _transform);
            transform.localScale = new Vector3(obstacle.Size, obstacle.Size, 1);

            isInit = true;
        }
        
        public void DestroyObstacle()
        {
            BeforeDestroy?.Invoke(this);
            Destroy(gameObject);
        }

        private void Update()
        {
            if (!isInit) return;
            UpdateActions();
            
            
            obstaclesScreen.Check();
            Obstacle.Advance(Time.deltaTime);

            _transform.position = Obstacle.Position;
            _transform.eulerAngles = new Vector3(0, 0, Obstacle.Rotation);
        }

        protected virtual void UpdateActions() { }
    }
}