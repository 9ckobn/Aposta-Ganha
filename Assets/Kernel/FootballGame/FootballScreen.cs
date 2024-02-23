using Foot;
using UnityEngine;

public class FootballScreen : UIScreen
{
    [SerializeField] private Foot.Header header;
    [SerializeField] private MainMenuScreen mainMenu;
    [SerializeField] private GameScreen gameScreen;
    [SerializeField] private Game.GameSelector gameSelector;
    [SerializeField] private GameHandler handler;

    public GameObject winOpen;

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
        // return gameSelector.SetupScreen();
        
        return gameScreen;
    }

    public UIScreen BackToMainMenu()
    {
        gameScreen.CloseScreen();
        gameSelector.gameObject.SetActive(false);

        


        CloseScreen();
        handler.ClearGame();
        handler.gameObject.SetActive(false);
        
        // gameScreen.CloseScreen();
        return mainMenu;
    }

}
