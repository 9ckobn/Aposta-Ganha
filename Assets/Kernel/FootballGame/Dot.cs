using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Dot : MonoBehaviour
{
    public BoxCollider2D collider;
    public DotType myType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (myType == DotType.enemy)
        {
            other.transform.DOKill();
            other.gameObject.SetActive(false);
        }
    }
}


public enum DotType
{
    available,
    enemy,
    goal
}