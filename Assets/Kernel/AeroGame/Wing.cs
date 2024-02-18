using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Wing : MonoBehaviour
{
    public Action onOil, onBomb;

    public Image boom;

    public TextMeshProUGUI winText;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Obstacle>(out var obstacle))
        {
            if (obstacle.myType == Type.bomb)
            {
                boom.rectTransform.DOScale(10, .25f).SetEase(Ease.OutExpo).SetLoops(2, LoopType.Yoyo);

                onBomb?.Invoke();
                Debug.Log($"boom");
            }
            else
            {
                winText.DOFade(0, 0);
                winText.enabled = true;
                winText.DOFade(1, .7f).SetLoops(2, LoopType.Yoyo).OnComplete(() => winText.enabled = false);

                onOil?.Invoke();
                Debug.Log($"+10 sec");
            }

            obstacle.gameObject.SetActive(false);

            obstacle.myImage.rectTransform.DOKill();
        }
    }

    public void ClearWing()
    {
        winText.DOFade(0,0);
        winText.enabled = false;

        boom.rectTransform.DOScale(0,0);
    }
}