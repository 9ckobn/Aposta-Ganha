using Foot;
using UnityEngine;

public class FootballScreen : UIScreen
{
    [SerializeField] private Foot.Header header;
    [SerializeField] private MainMenuScreen mainMenu;
    [SerializeField] private GameScreen gameScreen;
    [SerializeField] private Game.GameSelector gameSelector;
    [SerializeField] private GameHandler handler;

    public override void StartScreen()
    {
        gameObject.SetActive(true);

        header.SetupHeader(this);

        Debug.Log($"foot");
    }

    public UIScreen OpenSelect()
    {
        return gameSelector.SetupScreen();
    }

    public UIScreen OpenGame()
    {
        gameSelector.SetupScreen();
        return gameScreen;
    }

    public UIScreen BackToMainMenu()
    {
        gameScreen.CloseScreen();
        handler.ClearGame(true);

        handler.gameObject.SetActive(false);

        CloseScreenWithAnimation();
        gameScreen.CloseScreen();
        return mainMenu;
    }

}
