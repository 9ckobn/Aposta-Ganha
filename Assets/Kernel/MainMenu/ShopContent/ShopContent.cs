using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Aposta Ganha/ShopContent")]
public class ShopContent : ScriptableObject
{
    public ShopItem defaultPrefab;
    public List<Element> allItems;
}

[Serializable]
public class Element
{
    public bool IsPurchased() => PlayerPrefs.GetInt(Sprite.name, 0) == 1;

    public int Price;

    public Sprite Sprite;

    public void Buy()
    {
        if (PlayerStats.MoneyCount > Price)
        {
            PlayerPrefs.SetInt(Sprite.name, 1);
            PlayerStats.MoneyCount -= Price;
        }
    }
}