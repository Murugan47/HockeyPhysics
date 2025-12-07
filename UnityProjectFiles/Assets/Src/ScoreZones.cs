using UnityEngine;

public class ScoreZones : MonoBehaviour
{
    [SerializeField] private Scoring scoring;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("PlayerGoal"))
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                Destroy(collision.gameObject);
            }
            scoring.ScoringChecker("player");
            SoundPlayer.ScoreSound();
        }

        else if (gameObject.CompareTag("AIGoal"))
        {
            if (collision.gameObject.CompareTag("Ball"))
            {
                Destroy(collision.gameObject);
            }
            scoring.ScoringChecker("ai");
            SoundPlayer.ScoreSound();
        }
    }

}
