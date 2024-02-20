using System.Threading.Tasks;
using Aero;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class GameSelector : MonoBehaviour
    {
        [SerializeField] DefaultScreen main, extra;
        [SerializeField] private Foot.GameHandler handler;

        [SerializeField] private Button startButton;

        public UIScreen SetupScreen()
        {
            handler.ClearGame(true);
            handler.gameObject.SetActive(false);
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