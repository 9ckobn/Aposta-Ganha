using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image), typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Obstacle : MonoBehaviour
{
    public Image myImage;

    public Type myType;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private BoxCollider2D _col;

    void Awake()
    {
        myImage = GetComponent<Image>();

        myImage.rectTransform.DOAnchorPosY(-5000, 20);
    }
}

public enum Type
{
    bomb,
    oil
}