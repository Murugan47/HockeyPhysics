using UnityEngine;
using TMPro;

public class Scoring : MonoBehaviour
{
    [SerializeField] private GameObject puckPrefab;
    public TMP_Text playerScoreText;
    public TMP_Text aiScoreText;
    public int playerScore;
    public int aiScore;

    public void ScoringChecker(string scorer)
    {

        if (scorer == "ai")
        {
            aiScore++;
            aiScoreText.text = aiScore.ToString();
            if (aiScore == 10)
            {
                Instantiate(puckPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(puckPrefab, new Vector3(-3, 0, 0), Quaternion.identity);
            }
        }
        else if (scorer == "player")
        {
            playerScore++;
            playerScoreText.text = playerScore.ToString();
            if (playerScore == 10)
            {
                Instantiate(puckPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(puckPrefab, new Vector3(3, 0, 0), Quaternion.identity);
            }
        }

    }

}