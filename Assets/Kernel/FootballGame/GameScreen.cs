using Foot;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameScreen : UIScreen
{
    [SerializeField] private GameHandler gameHandler;
    [SerializeField] private GameObject winGame;

    [SerializeField] private Button retry;

    [SerializeField] private TextMeshProUGUI total;
    public override void StartScreen()
    {
        onClosing = () => winGame.SetActive(false);

        winGame.SetActive(false);

        gameObject.SetActive(true);
        gameHandler.ClearGame(true);
        gameHandler.StartGame();

        gameHandler.onEnd = (value) =>
        {
            total.text = $"total win \n{value * 50}";
            gameHandler.gameObject.SetActive(false);
            winGame.SetActive(true);
            gameHandler.ClearGame();
        };

        retry.onClick.RemoveAllListeners();
        retry.onClick.AddListener(() =>
        {
            gameHandler.gameObject.SetActive(true);
            Debug.Log("try to close wingame screen");
            winGame.SetActive(false);
            PlayerStats.MoneyCount += gameHandler.myScore * 50;
            gameHandler.ClearGame(true);
            gameHandler.StartGame();
        });
        // throw new System.NotImplementedException();
    }


}