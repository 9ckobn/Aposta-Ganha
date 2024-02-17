using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class RulesScreen : UIScreen
{
    [SerializeField] private Button myButton;

    public override void StartScreen()
    {
        onClosing = () => myButton.transform.DOScale(1, 0.1f).OnComplete(() => myButton.gameObject.SetActive(true));

        gameObject.SetActive(true);
        myButton.transform.DOScale(0, 0.1f).OnComplete(() => myButton.gameObject.SetActive(false));
    }
}
