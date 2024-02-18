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
        winGame.SetActive(false);

        gameObject.SetActive(true);
        gameHandler.ClearGame(true);
        gameHandler.StartGame();

        gameHandler.onEnd = () =>
        {
            total.text = $"total win \n{gameHandler.myScore}";
            winGame.SetActive(true);
        };

        retry.onClick.RemoveAllListeners();
        retry.onClick.AddListener(() =>
        {
            PlayerStats.MoneyCount += gameHandler.myScore * 50;
            gameHandler.ClearGame(true);
        });
        // throw new System.NotImplementedException();
    }


}