using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool onTarget = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        onTarget = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onTarget = false;
    }
}
