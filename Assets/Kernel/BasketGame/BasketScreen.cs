using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Basket;

public class BasketScreen : UIScreen
{   
    [SerializeField] private Basket.GameSelector gameSelector;

    public override void StartScreen()
    {
        gameObject.SetActive(true);

        gameSelector.Setup();
        // throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
