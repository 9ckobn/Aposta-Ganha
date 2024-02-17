using UnityEngine;

public class BootStrap : MonoBehaviour
{
    public BootScreen startScreen;

    void Awake()
    {
        
    }

    void Start()
    {
        startScreen.StartScreen();
    }
}