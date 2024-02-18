using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aero
{
    public class Header : MonoBehaviour
    {
        [SerializeField] private Button back, rules;

        [SerializeField] private UIScreen rulesScreen;
        [SerializeField] private TextMeshProUGUI moneyCount;

        private UIScreen currentScreen;

        public void SetupHeader(AeroScreen aero)
        {
            moneyCount.text = $"{PlayerStats.MoneyCount}";

            PlayerStats.onMoneyCountChanged += (value) => this.moneyCount.text = $"{value}";

            currentScreen = aero.OpenChooseGame();

            rules.onClick.AddListener(async () =>
            {
                currentScreen = await currentScreen.GetNextScreen(rulesScreen);
            });

            back.onClick.AddListener(async () =>
            {
                currentScreen = await currentScreen.GetNextScreen(currentScreen is RulesScreen ? aero.OpenChooseGame() : aero.BackToMainMenu());
            });
        }
    }
}
