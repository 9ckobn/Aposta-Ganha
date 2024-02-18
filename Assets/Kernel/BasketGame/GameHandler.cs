using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Basket
{
    public class GameHandler : UIScreen, IPointerDownHandler
    {
        [Header("UI")]

        [SerializeField] private TextMeshProUGUI home, away, timer;
        [SerializeField] private Image target, ball;
        [SerializeField] private Button start;

        [SerializeField] TextMeshProUGUI onTargetText, winCountText;

        [SerializeField] private GameObject winOpen;
        [SerializeField] private TextMeshProUGUI totalWin;

        [SerializeField] private Button retry;

        private int homeScore, awayScore;

        private Ball _ball;

        public float AnimationDuration = 1;

        System.Action<Vector3> onClick;

        private Vector3 initialPosition;

        private bool inGame = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            onClick?.Invoke(eventData.position);
        }

        private async void BallJump(Vector3 targetPosition)
        {
            if (!inGame)
                return;

            onClick = null;

            ball.rectTransform.DOJump(targetPosition, 150, 1, AnimationDuration).SetEase(Ease.OutQuad);
            ball.rectTransform.DOScale(0.33f, AnimationDuration);
            await ball.rectTransform.DORotate(new Vector3(0, 0, Random.Range(0, 720)), AnimationDuration, RotateMode.FastBeyond360).AsyncWaitForCompletion();

            if (_ball.onTarget)
            {
                Show(true);

                winCountText.gameObject.SetActive(true);
                await winCountText.DOFade(1, AnimationDuration / 4).AsyncWaitForCompletion();
                await winCountText.DOFade(0, AnimationDuration / 4).AsyncWaitForCompletion();

                homeScore += 1;
                home.text = $"{homeScore}";
            }
            else
            {
                Show(false);

                awayScore += 1;
                away.text = $"{awayScore}";
            }

            ClearBall();
        }

        private async void Show(bool win)
        {
            Vector3 offset = new Vector3(-100, -150, 0);

            onTargetText.rectTransform.position = ball.rectTransform.position + offset;

            if (win)
            {
                // onTargetText.rectTransform.position = ball.rectTransform.position + offset;
                onTargetText.color = Color.yellow;
                onTargetText.text = "WIN";
                // await onTargetText.DOFade(0.8f, AnimationDuration / 4).AsyncWaitForCompletion();
            }
            else
            {
                onTargetText.color = Color.white;
                onTargetText.text = "Lose";
            }

            onTargetText.gameObject.SetActive(true);

            await onTargetText.DOFade(0.8f, AnimationDuration / 4).AsyncWaitForCompletion();
            await onTargetText.DOFade(0, AnimationDuration / 4).AsyncWaitForCompletion();
        }

        private void ClearBall()
        {
            ball.rectTransform.localScale = Vector3.one;
            ball.rectTransform.position = initialPosition;
            ball.rectTransform.localEulerAngles = Vector3.zero;

            onClick = BallJump;
        }

        private IEnumerator Timer()
        {
            inGame = true;

            int total = 30;

            YieldInstruction waitSec = new WaitForSeconds(1);

            while (total > 1)
            {
                total--;

                timer.text = $"0:{total}";

                yield return waitSec;
            }

            inGame = false;
            timer.text = $"0:0";
            target.rectTransform.DOPause();

            winOpen.SetActive(true);
            totalWin.text = $"total win is \n{homeScore * 50}";

            PlayerStats.MoneyCount += homeScore * 50;
        }

        void StartGame()
        {
            winOpen.SetActive(false);

            // retry.gameObject.SetActive(false);
            start.gameObject.SetActive(false);

            StartCoroutine(Timer());

            _ball = ball.GetComponent<Ball>();

            target.rectTransform.DOAnchorPosX(720, 2.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);

            onClick = BallJump;
        }

        public async void StopGame()
        {
            winOpen.SetActive(false);

            timer.text = "0:30";
            inGame = false;
            onClick = null;
            ClearBall();

            onTargetText.gameObject.SetActive(false);
            winCountText.gameObject.SetActive(false);

            target.rectTransform.DOKill();
            target.rectTransform.anchoredPosition = new Vector3(-720, 0);

            home.text = "0";
            away.text = "0";

            homeScore = 0;
            awayScore = 0;

            start.gameObject.SetActive(true);
        }

        public override void StartScreen()
        {
            initialPosition = ball.rectTransform.position;
            StopGame();

            gameObject.SetActive(true);

            start.onClick.RemoveAllListeners();
            retry.onClick.RemoveAllListeners();

            start.onClick.AddListener(StartGame);
            retry.onClick.AddListener(StopGame);

        }
    }
}