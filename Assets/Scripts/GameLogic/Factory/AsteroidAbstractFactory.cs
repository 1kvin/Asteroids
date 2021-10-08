using GameLogic.Obstacles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameLogic.Factory
{
    public class AsteroidAbstractFactory : ObstacleAbstractFactory
    {
        [SerializeField] private AsteroidShardAbstractFactory asteroidShardAbstractFactory;
        [SerializeField] private int maxAsteroidShards;

        protected override void OnDestroyObject(ObstacleBehaviour obstacleBehaviour)
        {
            var shardCount = Random.Range(1, maxAsteroidShards + 1);
            asteroidShardAbstractFactory.InstantiateObjects(shardCount, obstacleBehaviour.Obstacle.Position);

            base.OnDestroyObject(obstacleBehaviour);
        }
    }
}