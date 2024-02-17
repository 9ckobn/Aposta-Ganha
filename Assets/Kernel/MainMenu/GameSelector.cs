using System.Collections;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameSelector : UIScreen
{
    public DefaultScreen main, extra;

    #region main
    [Header("Main")]
    [SerializeField] private GameTypeConfig config;

    [SerializeField] private Button basket, aero, foot;
    #endregion

    #region extras
    [Header("Extra")]
    [SerializeField] private Image extraImage;
    [SerializeField] private Button play;

    [SerializeField] private Button basketExtra, aeroExtra, footExtra;

    [SerializeField] private Image progress;
    #endregion

    public override async void StartScreen()
    {
        Debug.Log($"trying to open me");

        main.StartScreen();
        await extra.CloseScreenWithAnimation();

        gameObject.SetActive(true);

        SetupMainButtons();

        SetupExtraButtons();
    }


    private void SetupMainButtons()
    {
        basket.onClick.RemoveAllListeners();
        aero.onClick.RemoveAllListeners();
        foot.onClick.RemoveAllListeners();

        basket.onClick.AddListener(() => OpenExtraScreen(GameType.basket));
        aero.onClick.AddListener(() => OpenExtraScreen(GameType.aero));
        foot.onClick.AddListener(() => OpenExtraScreen(GameType.foot));

        // throw new NotImplementedException();
    }

    private void SetupExtraButtons()
    {
        basketExtra.onClick.RemoveAllListeners();
        aeroExtra.onClick.RemoveAllListeners();
        footExtra.onClick.RemoveAllListeners();

        basketExtra.onClick.AddListener(() => StartCoroutine(OpenExtra(GameType.basket)));
        aeroExtra.onClick.AddListener(() => StartCoroutine(OpenExtra(GameType.aero)));
        footExtra.onClick.AddListener(() => StartCoroutine(OpenExtra(GameType.foot)));

        // throw new NotImplementedException();
    }

    public async void OpenExtraScreen(GameType type)
    {
        await main.GetNextScreen(extra);

        extraImage.sprite = config.gameDataKvps.First(value => value.MyType == type).ExtraSprite;

        play.onClick.RemoveAllListeners();

        switch ((int)type)
        {
            case 0:
                await progress.rectTransform.DOAnchorPosX(-220, 0.3f).AsyncWaitForCompletion();
                break;
            case 1:
                await progress.rectTransform.DOAnchorPosX(0, 0.3f).AsyncWaitForCompletion();
                break;
            case 2:
                await progress.rectTransform.DOAnchorPosX(220, 0.3f).AsyncWaitForCompletion();
                break;
        }
        
        Debug.Log($"done");
    }

    public IEnumerator OpenExtra(GameType type)
    {
        yield return extraImage.DOFade(0, 0.15f).WaitForCompletion();

        extraImage.sprite = config.gameDataKvps.First(value => value.MyType == type).ExtraSprite;

        switch ((int)type)
        {
            case 0:
                progress.rectTransform.DOAnchorPosX(-220, 0.3f);
                break;
            case 1:
                progress.rectTransform.DOAnchorPosX(0, 0.3f);
                break;
            case 2:
                progress.rectTransform.DOAnchorPosX(220, 0.3f);
                break;
        }

        yield return extraImage.DOFade(1, 0.15f).WaitForCompletion();


        play.onClick.RemoveAllListeners();

        Debug.Log($"done");
    }


}

