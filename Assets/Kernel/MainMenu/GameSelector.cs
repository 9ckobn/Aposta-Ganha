using System.Collections;
using System.Linq;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameSelector : UIScreen
{
    public MainMenuScreen mainMenuScreen;
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

    private int currentType;

    public BasketScreen basketScreen;
    public Aero.AeroScreen aeroScreen;
    public FootballScreen footballScreen;
    #endregion

    public override void StartScreen()
    {
        main.StartScreen();
        extra.CloseScreen();

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

        currentType = (int)type;

        switch (currentType)
        {
            case 0:
                play.onClick.AddListener(async () => await mainMenuScreen.GetNextScreen(basketScreen));
                await progress.rectTransform.DOAnchorPosX(-220, 0.3f).AsyncWaitForCompletion();
                break;
            case 1:
                play.onClick.AddListener(async () => await mainMenuScreen.GetNextScreen(aeroScreen));
                await progress.rectTransform.DOAnchorPosX(0, 0.3f).AsyncWaitForCompletion();
                break;
            case 2:
                play.onClick.AddListener(async () => await mainMenuScreen.GetNextScreen(footballScreen));
                await progress.rectTransform.DOAnchorPosX(220, 0.3f).AsyncWaitForCompletion();
                break;
        }


        Debug.Log($"done");
    }

    public IEnumerator OpenExtra(GameType type)
    {
        yield return extraImage.rectTransform.DOAnchorPosX((int)type > currentType ? 2500 : -2500, 0.15f).WaitForCompletion();

        extraImage.sprite = config.gameDataKvps.First(value => value.MyType == type).ExtraSprite;

        play.onClick.RemoveAllListeners();

        currentType = (int)type;

        switch (currentType)
        {
            case 0:
                play.onClick.AddListener(async () => await mainMenuScreen.GetNextScreen(basketScreen));
                yield return progress.rectTransform.DOAnchorPosX(-220, 0.3f).WaitForCompletion();
                break;
            case 1:
                play.onClick.AddListener(async () => await mainMenuScreen.GetNextScreen(aeroScreen));
                yield return progress.rectTransform.DOAnchorPosX(0, 0.3f).WaitForCompletion();
                break;
            case 2:
                play.onClick.AddListener(async () => await mainMenuScreen.GetNextScreen(footballScreen));
                yield return progress.rectTransform.DOAnchorPosX(220, 0.3f).WaitForCompletion();
                break;
        }

        yield return extraImage.rectTransform.DOAnchorPosX(0, 0.15f).WaitForCompletion();


        // play.onClick.RemoveAllListeners();

        Debug.Log($"done");
    }


}

