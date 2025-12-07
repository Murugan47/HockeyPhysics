using UnityEngine;

public class PuckCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            SoundPlayer.BounceSound();
        }

        if (collision.gameObject.CompareTag("Puck"))
        {
            SoundPlayer.PuckSound();
        }
    }
}
