using UnityEngine;

public class MainMenuScreen : UIScreen
{
    public Header header;
    public Footer footer;

    [SerializeField] private UIScreen gameSelectorScreen;

    public override void StartScreen()
    {
        gameObject.SetActive(true);

        Debug.Log($"start");
        header.SetupHeader();
        Debug.Log($"continue");
        footer.SetupFooter(this);
        Debug.Log($"end");

        // gameSelectorScreen.StartScreen();
    }

    public UIScreen OpenMainScreen()
    {
        gameSelectorScreen.StartScreen();
        return gameSelectorScreen;
    }

}
