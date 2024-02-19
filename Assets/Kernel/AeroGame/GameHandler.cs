using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Aero
{
    public class GameHandler : UIScreen
    {
        [SerializeField] private GameObject winOpen;

        [SerializeField] private Button start, retry;

        [SerializeField] private MovingButton toRight, toLeft;

        [SerializeField] private TextMeshProUGUI time, totalWin;

        [SerializeField] private Image wing;

        private Wing _wing;

        [SerializeField] private RectTransform obstaclePoint;

        [SerializeField] private Obstacle oil, bomb;

        public float MaxDistance;

        private Vector2 initialPosition;

        private int totalTime = 150;
        private bool inGame;
        private int totalOil = 0;

        void StartGame()
        {
            var direction = new Vector2(5f, 0);

            _wing.onOil = () =>
            {
                totalOil++;
                totalTime += 5;
                time.text = TimeSpan.FromSeconds(totalTime).ToString(@"mm\:ss");
            };

            _wing.onBomb = () =>
            {
                if (totalTime - 15 < 0)
                {
                    time.text = TimeSpan.FromSeconds(0).ToString(@"mm\:ss");

                    StopGame();
                }
                else
                {
                    totalTime -= 15;

                    time.text = TimeSpan.FromSeconds(totalTime).ToString(@"mm\:ss");
                }
            };

            toLeft.onPress = () =>
            {
                if ((wing.rectTransform.anchoredPosition - direction).x < -1 * MaxDistance)
                    return;


                wing.rectTransform.anchoredPosition -= direction;
            };

            toRight.onPress = () =>
            {
                if ((wing.rectTransform.anchoredPosition + direction).x > MaxDistance)
                    return;

                wing.rectTransform.anchoredPosition += direction;
            };

            winOpen.SetActive(false);

            start.gameObject.SetActive(false);

            StartCoroutine(Timer());
            StartCoroutine(ObstacleGenerator());
        }

        IEnumerator ObstacleGenerator()
        {
            YieldInstruction waitRandomSec = new WaitForSeconds(UnityEngine.Random.Range(1f, 3f));

            while (inGame)
            {
                yield return waitRandomSec;

                var randomIndex = UnityEngine.Random.Range(0, 2);

                var go = Instantiate(randomIndex == 1 ? oil : bomb, obstaclePoint);

                go.myImage.rectTransform.anchoredPosition = new Vector2(UnityEngine.Random.Range((int)-MaxDistance, (int)MaxDistance), -500);
            }
        }

        private IEnumerator Timer()
        {
            inGame = true;

            YieldInstruction waitsec = new WaitForSeconds(1);

            while (totalTime > 1)
            {
                totalTime--;

                time.text = TimeSpan.FromSeconds(totalTime).ToString(@"mm\:ss");

                yield return waitsec;
            }

            StopGame();
        }

        public async void StopGame()
        {
            StopAllCoroutines();

            foreach (var item in obstaclePoint.GetComponentsInChildren<Obstacle>())
            {
                item.gameObject.SetActive(false);
            }

            wing.rectTransform.anchoredPosition = initialPosition;

            winOpen.SetActive(true);
            // start.gameObject.SetActive(false);
            int win = totalOil * 50;

            totalWin.text = $"<color=#4581F5>total win</color> \n<color=orange>{win}</color>";
            PlayerStats.MoneyCount += win;

            retry.onClick.AddListener(ClearGame);
        }

        public void ClearGame()
        {
            StopAllCoroutines();

            foreach (var item in obstaclePoint.GetComponentsInChildren<Obstacle>())
            {
                item.gameObject.SetActive(false);
            }

            _wing.ClearWing();

            wing.rectTransform.anchoredPosition = initialPosition;

            totalOil = 0;
            totalTime = 150;

            time.text = TimeSpan.FromSeconds(totalTime).ToString(@"mm\:ss");

            winOpen.SetActive(false);
            start.gameObject.SetActive(true);
        }

        public override void StartScreen()
        {
            if (initialPosition == Vector2.zero)
            {
                initialPosition = wing.rectTransform.anchoredPosition;
            }
            _wing = wing.GetComponent<Wing>();
            // StopGame();
            retry.onClick.RemoveAllListeners();

            ClearGame();

            gameObject.SetActive(true);

            start.onClick.RemoveAllListeners();

            start.onClick.AddListener(StartGame);
        }
    }
}