using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScreen : UIScreen
{
    [SerializeField] private Button myButton, sound, music;
    [SerializeField] private Sprite defaultS, selectedS;

    private bool soundIs = true, musicIs = false;

    public override void StartScreen()
    {
        gameObject.SetActive(true);

        Debug.Log($"screen ready");

        onClosing = () => myButton.transform.DOScale(1, 0.3f).OnComplete(() => myButton.gameObject.SetActive(true));
        myButton.transform.DOScale(0, 0.1f).OnComplete(() => myButton.gameObject.SetActive(false));

        sound.onClick.RemoveAllListeners();
        music.onClick.RemoveAllListeners();

        sound.onClick.AddListener(SwitchSound);
        music.onClick.AddListener(SwitchMusic);
    }

    void SwitchSound()
    {
        soundIs = !soundIs;

        sound.targetGraphic.GetComponent<Image>().sprite = soundIs ? selectedS : defaultS;
    }

    void SwitchMusic()
    {
        musicIs = !musicIs;

        music.targetGraphic.GetComponent<Image>().sprite = musicIs ? selectedS : defaultS;
    }
}