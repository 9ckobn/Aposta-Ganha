using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShopItem : MonoBehaviour
{
    public Image Image;
    public Button buy;

    void Start()
    {
        Debug.Log($"Hello");
        buy = GetComponent<Button>();

        Image = buy.targetGraphic as Image;
    }
}