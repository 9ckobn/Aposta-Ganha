using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BootScreen : UIScreen
{
    public float WaitTime = 3;
    public float NoiseForLoading = 5;

    private float loadProgress = 0;

    [SerializeField] private Slider progressBar;
    [SerializeField] private GameObject loader, logo;

    [SerializeField] private Button playButton;

    [SerializeField] private UIScreen mainMenuScreen;


    public override void StartScreen()
    {
        gameObject.SetActive(true);
        progressBar.interactable = false;

        progressBar.maxValue = WaitTime;

        StartCoroutine(ProgressRunner());
    }

    IEnumerator ProgressRunner()
    {
        while (loadProgress < WaitTime)
        {
            loadProgress += Time.deltaTime;

            for (int i = 0; i < Random.Range(1, NoiseForLoading); i++)
            {
                yield return null;
            }

            progressBar.value = loadProgress;
        }

        loader.SetActive(false);

        RunButton();
    }

    private void RunButton()
    {
        logo.transform.DOScale(1.35f, 0.3f);

        playButton.targetGraphic.DOFade(0, 0);

        playButton.gameObject.SetActive(true);

        playButton.targetGraphic.DOFade(1, 0.3f);

        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(async () =>
        {
            await GetNextScreen(mainMenuScreen);
        }
        );
    }
}
