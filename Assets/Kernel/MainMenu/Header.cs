using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Header : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyText;

    [SerializeField] private Button openShop, openAbout;

    [SerializeField] private UIScreen shopScreen;

    public Footer footer;

    public void SetupHeader()
    {
        moneyText.text = MoneyCount();

        PlayerStats.onMoneyCountChanged += (value) => this.moneyText.text = $"{value}";

        SetupButtons();
    }

    private void SetupButtons()
    {
        openAbout.onClick.AddListener(() => Application.OpenURL(Constants.aboutUsUrl)); //todo rewrite to native webview

        // openShop.onClick.AddListener(() => footer.OpenNextScreen(shopScreen));

        // throw new NotImplementedException();
    }

    private string MoneyCount() => $"{PlayerStats.MoneyCount}";
}
