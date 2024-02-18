using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WingsLayout : DefaultScreen
{
    [SerializeField] private List<Button> wings;

    public Sprite defaultSprite, selectedSprite;

    public UIScreen game;

    [SerializeField] private Button start;

    Sprite currentWing;

    public override void StartScreen()
    {
        base.StartScreen();

        foreach (var item in wings)
        {
            item.interactable = false;
        }

        wings[0].interactable = true;
        wings[0].targetGraphic.GetComponent<Image>().sprite = selectedSprite;

        wings[0].onClick.AddListener(async () => currentWing = wings[0].GetComponentInChildren<Image>().sprite);

        start.onClick.AddListener(async () => await GetNextScreen(game));
    }
}
