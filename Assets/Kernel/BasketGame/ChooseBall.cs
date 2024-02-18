using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Basket
{
    public class ChooseBall : DefaultScreen
    {
        [SerializeField] private Button choose;
        [SerializeField] private TextMeshProUGUI chooseText;

        private const string chooseString = "choose";
        private const string cantChooseString = "<sprite=0>";

        [SerializeField] private PageSwiper pageSwiper;

        [SerializeField] private List<Shop.Ball> allBalls;
        private Shop.Ball currentBall;

        [SerializeField] private GameHandler game;

        public override void StartScreen()
        {
            gameObject.SetActive(true);

            CheckIfBuyed(0);

            pageSwiper.onPageChanged = (page) =>
            {
                CheckIfBuyed(page);
            };
        }

        private void CheckIfBuyed(int currentIndex)
        {
            if (currentIndex > 3)
            {
                chooseText.text = cantChooseString;
                choose.interactable = false;
            }
            else
            {
                chooseText.text = chooseString;
                choose.interactable = true;

                choose.onClick.RemoveAllListeners();

                choose.onClick.AddListener(async () =>
                {
                    currentBall = allBalls[currentIndex];

                    await GetNextScreen(game);
                });
            }

            // return PlayerPrefs.GetInt(currentBall.myShopName) == 1;
        }
    }

    namespace Shop
    {
        [Serializable]
        public struct Ball
        {
            public Sprite Sprite;
            public string myShopName;
        }
    }
}