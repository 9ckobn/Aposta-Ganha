using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Foot
{

    public class GameHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private LineRenderer inputLine, inGameLine;

        [SerializeField] private List<GameObject> variants;
        [SerializeField] private TextMeshProUGUI score, timer;

        private List<Dot> path;

        public Dot lastDot;

        public GameObject Ball;

        Camera cam;

        public Vector3 lineOffset;
        public Vector3 initialPosition;

        public int myScore, enemyScore;

        private int totalTime = 30;

        private bool clear = false;
        public Action<int> onEnd;

        IEnumerator timerRoutine;

        public void StartGame()
        {


            // if (TimerRoutine().)

            ClearGame(false);

            if (timerRoutine == null)
            {
                timerRoutine = TimerRoutine();

            StartCoroutine(timerRoutine);
            }

            // gameObject.SetActive(true);

            cam = Camera.main;
            

    if (path != null)
    {

		foreach (var item in path)
{
item.collider.enabled = true;
}
    }

            path = new List<Dot>();
            path.Add(lastDot);

            inputLine.positionCount = 2;
            inGameLine.positionCount = 1;

            // inputLine.transform.localPosition = lastDot.transform.localPosition;
            inputLine.SetPosition(0, lastDot.transform.localPosition + lineOffset);
            inGameLine.SetPosition(0, lastDot.transform.localPosition + lineOffset);

            inputLine.enabled = false;

            int index = UnityEngine.Random.Range(0, variants.Count);
            for (int i = 0; i < variants.Count; i++)
            {
                if (i == index)
                {
                    variants[i].SetActive(true);
                }
            }
        }

        private IEnumerator TimerRoutine()
        {
            YieldInstruction waitSec = new WaitForSeconds(1);
            totalTime = 30;

            while (totalTime > 0)
            {
                yield return waitSec;

                totalTime -= 1;

                timer.text = TimeSpan.FromSeconds(totalTime).ToString(@"mm\:ss");
            }

            onEnd?.Invoke(myScore);

            Debug.Log($"endgame");
        }

        public void ClearGame(bool needToClearData)
        {
            // Ball.transform.DOKill();
            gameObject.SetActive(true);
            Ball.transform.localPosition = initialPosition;
            Ball.SetActive(true);

            foreach (var item in variants)
            {
                item.SetActive(false);
            }

            inputLine.positionCount = 1;
            inGameLine.positionCount = 1;

            if (!needToClearData)
                return;

            timerRoutine = null;

            DOTween.KillAll();

            myScore = 0;
            enemyScore = 0;

            score.text = "0-0";

            StopAllCoroutines();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            inputLine.enabled = true;
        }

        public void OnDrag(PointerEventData eventData)
        {
            inputLine.SetPosition(1, cam.ScreenToWorldPoint(eventData.position));
        }

        public async void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.pointerEnter.TryGetComponent<Dot>(out var dot))
            {
                if (dot.myType == DotType.available || dot.myType == DotType.goal)
                {
                    path.Add(dot);

                    if (dot.myType == DotType.goal)
                    {

                    }
                    else
                    {
                        dot.collider.enabled = false;
                    }

                    inGameLine.enabled = true;

                    inGameLine.positionCount = path.Count;

                    inGameLine.SetPosition(inGameLine.positionCount - 1, dot.myType == DotType.goal ? cam.ScreenToWorldPoint(eventData.position) + new Vector3(0, 0, 15) : dot.transform.localPosition + lineOffset);

                    inputLine.SetPosition(0, dot.transform.localPosition + lineOffset);

                    if (dot.myType == DotType.goal)
                    {
                        inputLine.enabled = false;

                        foreach (var item in path)
                        {
                            await Ball.transform.DOMove(item.transform.position, 2).AsyncWaitForCompletion();
                        }

                        if (Ball.gameObject.activeSelf)
                        {
                            myScore++;
                            Debug.Log($"wingame");
                        }
                        else
                        {
                            enemyScore++;

                            Debug.Log($"lose");
                        }

                            dot.collider.enabled = true;
                        score.text = $"{myScore}-{enemyScore}";


                        StartGame();
                    }
                }
            }

            inputLine.enabled = false;

            inputLine.SetPosition(1, lastDot.transform.position);
        }
    }
}