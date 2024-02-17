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


        back.onClick.AddListener(async () =>
        {
            if (currentScreen is GameSelector)
            {
                currentScreen.StartScreen();
            }
            else
            {
                currentScreen = await currentScreen.GetNextScreen(mainScreen);
            }
        });


        rules.onClick.AddListener(async () =>
        {
            currentScreen = await currentScreen.GetNextScreen(rulesScreen);
        });

        settings.onClick.AddListener(async () => currentScreen = await currentScreen.GetNextScreen(settingsScreen));
    }
}
