using GameLogic.Actions;
using GameLogic.Factory;
using GameLogic.Input;
using GameLogic.Obstacles;
using GameLogic.PlayerBeh;
using UI.InGame;
using UnityEngine;
using Zenject;

namespace GameLogic
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private FactoryRegulator factoryRegulator;
        [SerializeField] private PlayerBehaviour playerBehaviourPrefab;
        [SerializeField] private GameOverAction gameOverAction;
        public Player Player { get; private set; }
        public int Score { get; set; }
        private IPlayerInput playerInput;

        [Inject]
        public void Construct(IPlayerInput playerInput)
        {
            this.playerInput = playerInput;

            factoryRegulator.InitAll(AddScore);
        }

        public void StartGame()
        {
            Score = 0;
            Player = InitPlayer();
        }

        private Player InitPlayer()
        {
            var player = Instantiate(playerBehaviourPrefab);
            player.BeforeDestroy += EndGame;
            return player.Init(playerInput);
        }

        private void AddScore(ObstacleBehaviour obstacleBehaviour)
        {
            Score += obstacleBehaviour.Obstacle.Gold;
        }

        private void EndGame(ObstacleBehaviour from)
        {
            gameOverAction.GameOver(Score);
        }
    }
}