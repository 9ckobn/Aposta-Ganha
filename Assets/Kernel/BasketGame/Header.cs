using UnityEngine;
using UnityEngine.UI;

namespace Basket
{
    public class Header : MonoBehaviour
    {
        [SerializeField] private Button back, rules, settings;

        [SerializeField] private MainMenuScreen mainMenu;

        [SerializeField] private UIScreen settingsScreen, rulesScreen;

        public void SetupHeader()
        {

        }
    }
}
