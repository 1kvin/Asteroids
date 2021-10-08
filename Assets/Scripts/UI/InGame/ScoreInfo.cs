using UnityEngine;
using UnityEngine.UI;

namespace UI.InGame
{
    public class ScoreInfo : MonoBehaviour
    {
        [SerializeField] private Text infoText;
        
        public void UpdateText(int score)
        {
            infoText.text = $"Score: {score}";
        }
    }
}
