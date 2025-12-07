using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Scoring scoring;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gamePlay;
    [SerializeField] private GameObject settings;
    [SerializeField] private Player player;
    [SerializeField] private TMP_Text winLoseText;

    void Update()
    {
        if (scoring.playerScore == 10)
        {
            scoring.playerScore = 0;
            scoring.aiScore = 0;
            scoring.playerScoreText.text = "0";
            scoring.aiScoreText.text = "0";
            // Textboxes are swapped dont fix it
            winLoseText.text = "You Lose :(";
            string gameState = "over";
            SoundPlayer.WinSound();
            MenuManager(gameState);

        }

        else if (scoring.aiScore == 10)
        {
            scoring.playerScore = 0;
            scoring.aiScore = 0;
            scoring.playerScoreText.text = "0";
            scoring.aiScoreText.text = "0";
            // Textboxes are swapped dont fix it
            winLoseText.text = "You Win!";
            string gameState = "over";
            SoundPlayer.WinSound();
            MenuManager(gameState);
        }
    }

    public void MenuManager(string gameState)
    {
        switch (gameState)
        {
            case "over":

                gameOver.SetActive(true);
                mainMenu.SetActive(false);
                gamePlay.SetActive(false);
                settings.SetActive(false);
                player.gameStarted = false;
                Time.timeScale = 0f;
                SoundPlayer.MenuSound();
                break;

            case "mainMenu":

                gameOver.SetActive(false);
                mainMenu.SetActive(true);
                gamePlay.SetActive(false);
                settings.SetActive(false);
                player.gameStarted = false;
                Time.timeScale = 0f;
                SoundPlayer.MenuSound();
                break;

            case "gamePlay":

                gameOver.SetActive(false);
                mainMenu.SetActive(false);
                gamePlay.SetActive(true);
                settings.SetActive(false);
                player.playerRB.position = new UnityEngine.Vector3(4, 0, 0);
                Time.timeScale = 1f;
                player.gameStarted = true;
                SoundPlayer.MenuSound();
                break;

            case "settings":
                gameOver.SetActive(false);
                gamePlay.SetActive(false);
                if (settings.activeSelf)
                {
                    settings.SetActive(false);
                }
                else
                {
                    settings.SetActive(true);
                }
                Time.timeScale = 0f;
                player.gameStarted = false;
                SoundPlayer.MenuSound();
                break;

        }
    }

}
