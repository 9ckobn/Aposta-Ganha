using UnityEngine;
using UnityEngine.UI;

namespace Basket
{
    public class GameSelector : MonoBehaviour
    {
        [SerializeField] DefaultScreen main, extra;

        [SerializeField] private Button startButton;

        public void Setup()
        {
            extra.CloseScreen();
            main.StartScreen();

            startButton.onClick.AddListener(async () => await main.GetNextScreen(extra));
        }
    }
}