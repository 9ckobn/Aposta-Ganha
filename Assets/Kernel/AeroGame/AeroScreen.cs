using UnityEngine;

namespace Aero
{
    public class AeroScreen : UIScreen
    {
        [SerializeField] private MainMenuScreen mainMenu;

        [SerializeField] private Game.GameSelector gameSelector;

        [SerializeField] private Aero.GameHandler gameScreen;

        [SerializeField] private Aero.Header header;

        public override void StartScreen()
        {
            gameObject.SetActive(true);

            
            header.SetupHeader(this);
        
        }

        public UIScreen OpenChooseGame()
        {
            return gameSelector.SetupScreen();
        }

        public UIScreen BackToMainMenu()
        {
            CloseScreenWithAnimation();
            gameScreen.CloseScreen();
            return mainMenu;
        }
    }
}
