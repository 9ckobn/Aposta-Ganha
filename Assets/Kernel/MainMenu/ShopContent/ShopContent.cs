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
    public bool IsPurchased = false;

    public int Price;

    public Sprite Sprite;

    public Element()
    {
        Debug.Log($"I am created with name {Sprite.name}");
    }

    public void Buy()
    {
        if (PlayerStats.MoneyCount > Price)
        {
            IsPurchased = true;
            PlayerStats.MoneyCount -= Price;
        }
    }
}