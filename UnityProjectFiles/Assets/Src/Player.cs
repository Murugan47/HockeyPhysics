using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private bool playerSelected = false;
    [SerializeField] public Rigidbody2D playerRB;
    [SerializeField] private BoxCollider2D playingField;
    public bool gameStarted = false;

    private void OnMouseDown()
    {
        playerSelected = true;
    }

    private void OnMouseUp()
    {
        playerSelected = false;
    }

    void FixedUpdate()
    {
        if (playerSelected && gameStarted)
        {
            UnityEngine.Vector2 clampedMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clampedMousePosition.x = Mathf.Clamp(clampedMousePosition.x, playingField.bounds.min.x, playingField.bounds.max.x);
            clampedMousePosition.y = Mathf.Clamp(clampedMousePosition.y, playingField.bounds.min.y, playingField.bounds.max.y);
            playerRB.MovePosition(clampedMousePosition);
        }
    }

}
