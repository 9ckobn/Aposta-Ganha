using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Basket
{
    public class Header : MonoBehaviour
    {
        [SerializeField] private Button back, rules;

        [SerializeField] private UIScreen rulesScreen;
        [SerializeField] private TextMeshProUGUI moneyCount;

        private UIScreen currentScreen;

        public void SetupHeader(BasketScreen basket)
        {
            moneyCount.text = $"{PlayerStats.MoneyCount}";

            PlayerStats.onMoneyCountChanged += (value) => this.moneyCount.text = $"{value}";

            currentScreen = basket.OpenChooseGame();

            rules.onClick.AddListener(async () =>
            {
                currentScreen = await currentScreen.GetNextScreen(rulesScreen);
            });

            back.onClick.AddListener(async () =>
            {
                currentScreen = await currentScreen.GetNextScreen(currentScreen is RulesScreen ? basket.OpenChooseGame() : basket.BackToMainMenu());
            });
        }
    }
}
