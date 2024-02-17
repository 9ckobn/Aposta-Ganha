using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShopItem : MonoBehaviour
{
    public Action onClick;
    public Sprite sprite;

    private Image Image;
    private Button buy;

    void Start()
    {
        Debug.Log($"Hello");
        buy = GetComponent<Button>();

        Image = buy.targetGraphic as Image;

        Image.sprite = sprite;
        buy.onClick.RemoveAllListeners();

        buy.onClick.AddListener(() => onClick?.Invoke());
    }
}