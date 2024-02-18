using UnityEngine;
using Basket;

public class BasketScreen : UIScreen
{
    [SerializeField] private MainMenuScreen mainMenu;

    [SerializeField] private Game.GameSelector gameSelector;

    [SerializeField] private Basket.GameHandler gameScreen;

    [SerializeField] private Basket.Header header;

    public override void StartScreen()
    {
        gameObject.SetActive(true);

        // gameSelector.SetupScreen();
        header.SetupHeader(this);
        // throw new System.NotImplementedException();
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
