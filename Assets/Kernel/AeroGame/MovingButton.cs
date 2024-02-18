using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovingButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action onPress;
    private bool isPressed;

    void OnEnable()
    {
        StartCoroutine(PressAction());
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log($"gg");
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log($"wp");
        isPressed = false;
    }

    private IEnumerator PressAction()
    {
        while (true)
        {
            while (isPressed)
            {
                onPress?.Invoke();
                yield return null;
            }

            yield return null;
        }
    }

}