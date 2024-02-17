using UnityEngine;
using UnityEngine.UI;

public class Footer : MonoBehaviour
{
    [SerializeField] private UIScreen rulesScreen, settingsScreen;

    [SerializeField] private Button back, settings, rules;

    private UIScreen mainScreen, currentScreen;

    public void SetupFooter(MainMenuScreen main)
    {
        back.onClick.RemoveAllListeners();
        settings.onClick.RemoveAllListeners();
        rules.onClick.RemoveAllListeners();

        currentScreen = main.OpenMainScreen();
        mainScreen = currentScreen;


        back.onClick.AddListener(() =>
        {
            if (currentScreen is GameSelector)
            {
                currentScreen.StartScreen();
            }
            else
            {
                OpenScreen(mainScreen);
            }
        });


        rules.onClick.AddListener(() =>
        {
            OpenScreen(rulesScreen);
        });

        settings.onClick.AddListener(() => OpenScreen(settingsScreen));
    }

    public async void OpenScreen(UIScreen next)
    {
        currentScreen = await currentScreen.GetNextScreen(next);
    }
}
