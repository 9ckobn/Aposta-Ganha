using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameSelector : MonoBehaviour
    {
        [SerializeField] DefaultScreen main, extra;

        [SerializeField] private Button startButton;

        public UIScreen SetupScreen()
        {
            extra.CloseScreen();
            main.StartScreen();

            startButton.onClick.AddListener(OpenChooserAsync);

            return main;
        }

        public async void OpenChooserAsync()
        {
            await main.GetNextScreen(extra);
        }
    }
}