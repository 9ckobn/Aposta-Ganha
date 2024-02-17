using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : UIScreen
{
    [SerializeField] private Button myButton;

    public override void StartScreen()
    {
        gameObject.SetActive(true);

        Debug.Log($"screen ready");

        onClosing = () => myButton.transform.DOScale(1, 0.3f).OnComplete(() => myButton.gameObject.SetActive(true));
        myButton.transform.DOScale(0, 0.1f).OnComplete(() => myButton.gameObject.SetActive(false));
    }
}