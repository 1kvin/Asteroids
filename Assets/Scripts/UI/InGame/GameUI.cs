using GameLogic;
using UnityEngine;

namespace UI.InGame
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private PlayerInfo playerInfo;
        [SerializeField] private ScoreInfo scoreInfo;
        [SerializeField] private Game game;
        

        private void Update()
        {
            UpdatePlayerInfo();
            UpdateScoreInfo();
        }

        private void UpdatePlayerInfo()
        {
            playerInfo.UpdateText(game.Player);
        }
        
        private void UpdateScoreInfo()
        {
            scoreInfo.UpdateText(game.Score);
        }
    }
}