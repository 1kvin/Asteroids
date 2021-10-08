using GameLogic.Factory;
using GameLogic.Obstacles;
using UI.EndGame;
using UI.InGame;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic.Actions
{
    public class GameOverAction : MonoBehaviour
    {
        [SerializeField] private FactoryRegulator factoryRegulator;
        [SerializeField] private GameUI gameUI;
        [SerializeField] private EndGameUI endGameUI;

        [SerializeField] private GameObject endGameCanvas;
        [SerializeField] private GameObject inGameCanvas;

        [SerializeField] private Text endGameText;
        [TextArea] [SerializeField] private string endGameTextTemplate;

        public void GameOver(int score)
        {
            EnableDisableObjects();
            DeleteObjects();
            SetEndGameText(score);
            factoryRegulator.StopAll();
            endGameUI.SetInputLock();
        }


        private void SetEndGameText(int score)
        {
            endGameText.text = endGameTextTemplate.Replace("@score", score.ToString());
        }

        private void DeleteObjects()
        {
            var obstacles = FindObjectsOfType<ObstacleBehaviour>();
            foreach (var obstacle in obstacles)
            {
                Destroy(obstacle.gameObject);
            }
        }

        private void EnableDisableObjects()
        {
            gameUI.enabled = false;
            endGameUI.enabled = true;

            inGameCanvas.SetActive(false);
            endGameCanvas.SetActive(true);
        }
    }
}