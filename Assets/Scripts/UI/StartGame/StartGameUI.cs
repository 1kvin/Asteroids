using GameLogic.Actions;
using UnityEngine;

namespace UI.StartGame
{
    public class StartGameUI : MonoBehaviour
    {
        [SerializeField] private StartGameAction startGameAction;
        
        private void Update()
        {
            if (Input.anyKey)
            {
                startGameAction.StartGame();
            }
        }
    }
}
