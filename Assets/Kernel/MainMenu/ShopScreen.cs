using System;
using UnityEngine;

public class ShopScreen : UIScreen
{
    [SerializeField] private ShopContent data;
    [SerializeField] private RectTransform gridLayout;

    private bool isSetupped = false;

    public override void StartScreen()
    {
        SetupShop();

        // throw new System.NotImplementedException();
    }

    private void SetupShop()
    {
        if (isSetupped)
            return;

        foreach (var item in data.allItems)
        {
            if (!item.IsPurchased)
            {
                var currentItem = Instantiate(data.defaultPrefab, gridLayout);

                // currentItem.buy.onClick.RemoveAllListeners();
                // currentItem.buy.onClick.AddListener(()=> item.Buy());

                currentItem.Image.sprite = item.Sprite;
            }
        }

        isSetupped = true;
        // throw new NotImplementedException();
    }
}