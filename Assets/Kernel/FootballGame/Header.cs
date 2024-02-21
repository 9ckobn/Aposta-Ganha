namespace Foot
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;


    public class Header : MonoBehaviour
    {
        [SerializeField] private Button back, rules;

        [SerializeField] private UIScreen rulesScreen;
        [SerializeField] private TextMeshProUGUI moneyCount;



        private UIScreen currentScreen;

        public void SetupHeader(FootballScreen aero)
        {
            rules.gameObject.SetActive(true);

            moneyCount.text = $"{PlayerStats.MoneyCount}";

            PlayerStats.onMoneyCountChanged += (value) => this.moneyCount.text = $"{value}";

            currentScreen = aero.OpenSelect();

            // currentScreen = aero.OpenGame();

            rules.onClick.AddListener(async () =>
            {
                currentScreen = await currentScreen.GetNextScreen(rulesScreen);
            });

            back.onClick.AddListener(async () =>
            {
                currentScreen = await currentScreen.GetNextScreen(currentScreen is RulesScreen ? aero.OpenSelect() : aero.BackToMainMenu());
            });
        }
    }
}

