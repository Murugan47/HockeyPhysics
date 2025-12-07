using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Rigidbody2D aiRB;
    [SerializeField] private PolygonCollider2D aiField;
    [SerializeField] private float aiSpeed = 15f;

    private GameObject puck;
    private Vector2 puckPosition;

    private void Start()
    {
        // Try to find the puck at startup
        puck = GameObject.FindGameObjectWithTag("Ball");
    }

    private void FixedUpdate()
    {
        // Try to re-acquire puck if it's been destroyed/reinstantiated
        if (puck == null)
        {
            puck = GameObject.FindGameObjectWithTag("Ball");
            if (puck == null) return; // still none, skip this frame
        }

        if (!player.gameStarted)
            return;

        puckPosition = puck.transform.position;
        Vector2 clampedPosition = aiField.ClosestPoint(puckPosition);

        Vector2 newPosition = Vector2.MoveTowards(aiRB.position, clampedPosition, aiSpeed * Time.fixedDeltaTime);
        aiRB.MovePosition(newPosition);
    }

    public void GameDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "Baby":
                aiSpeed = 1000f;
                SoundPlayer.MenuSound();
                break;

            case "Easy":
                aiSpeed = 5f;
                SoundPlayer.MenuSound();
                break;

            case "Medium":
                aiSpeed = 10f;
                SoundPlayer.MenuSound();
                break;

            case "Hard":
                aiSpeed = 15f;
                SoundPlayer.MenuSound();
                break;

            case "CrazyDave":
                aiSpeed = 25f;
                SoundPlayer.MenuSound();
                break;
        }
    }

}
