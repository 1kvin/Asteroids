using GameLogic.Factory;
using UI.EndGame;
using UI.InGame;
using UnityEngine;

namespace GameLogic.Actions
{
    public class RestartGameAction : MonoBehaviour
    {
        [SerializeField] private FactoryRegulator factoryRegulator;

        [SerializeField] private Game game;
        [SerializeField] private GameUI gameUI;
        [SerializeField] private EndGameUI endGameUI;

        [SerializeField] private GameObject endGameCanvas;
        [SerializeField] private GameObject inGameCanvas;

        public void RestartGame()
        {
            EnableDisableObjects();
            factoryRegulator.ClearAll();
            game.StartGame();
            factoryRegulator.StartAll();
        }

        private void EnableDisableObjects()
        {
            gameUI.enabled = true;
            endGameUI.enabled = false;

            inGameCanvas.SetActive(true);
            endGameCanvas.SetActive(false);
        }
    }
}