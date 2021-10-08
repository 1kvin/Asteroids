using GameLogic.Obstacles;
using GameLogic.Obstacles.Ufo;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace GameLogic.Factory
{
    public class UfoFactory : ObstacleAbstractFactory
    {
        [SerializeField] private Game game;
        protected override ObstacleBehaviour InstantiateObject(Vector3 pos)
        {
            var obs = base.InstantiateObject(pos);
            var ufo = (UfoBehaviour)obs;
            ufo.Init(game.Player);

            return obs;
        }
    }
}
