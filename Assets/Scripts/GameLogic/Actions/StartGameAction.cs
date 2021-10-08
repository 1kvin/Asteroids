using GameLogic.Factory;
using UI.InGame;
using UI.StartGame;
using UnityEngine;

namespace GameLogic.Actions
{
    public class StartGameAction : MonoBehaviour
    {
        [SerializeField] private FactoryRegulator factoryRegulator;

        [SerializeField] private Game game;
        [SerializeField] private GameObject startGameCanvas;
        [SerializeField] private GameObject inGameCanvas;
        [SerializeField] private GameUI gameUI;
        [SerializeField] private StartGameUI startGameUI;


        public void StartGame()
        {
            EnableDisableObjects();
            game.StartGame();
            factoryRegulator.StartAll();
        }

        private void EnableDisableObjects()
        {
            gameUI.enabled = true;
            startGameUI.enabled = false;

            inGameCanvas.SetActive(true);
            startGameCanvas.SetActive(false);
        }
    }
}