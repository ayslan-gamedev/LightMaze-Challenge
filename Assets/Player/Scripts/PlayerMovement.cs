using UnityEngine;
using MazeLabirint;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;

    [SerializeField] private PlayerAttributes playerAttributes;

    private Vector2 persistentDirection;
    private float currentSpeed;

#if UNITY_EDITOR
    [SerializeField] private float CurrentSpeed_DEGUG;
#endif

    private void Start()
    {
        // Get the Rigidbody2D component associated with this object
        rigidBody2D = GetComponent<Rigidbody2D>();

        // Find the GameManager and get the player attributes from it
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        if(gameManager != null && gameManager.GlobalVariables != null)
        {
            playerAttributes = gameManager.GlobalVariables.PlayerAttributes;
        }
    }

    private void FixedUpdate()
    {
        // Get the player's Horizontal and Vertical axis inputs
        Vector2 arrowsDirections = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // Calculate the current player speed based on inputs and attributes
        currentSpeed = arrowsDirections != Vector2.zero ? currentSpeed + playerAttributes.acceleration * Time.deltaTime : currentSpeed - playerAttributes.slowdown * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, 0, playerAttributes.speed);

        // Update the persistent direction of the player
        if(arrowsDirections != Vector2.zero)
        {
            persistentDirection = arrowsDirections;
        }

        // Apply the velocity to the Rigidbody2D to move the player
        rigidBody2D.velocity = persistentDirection * currentSpeed;

#if UNITY_EDITOR
        CurrentSpeed_DEGUG = currentSpeed;
#endif
    }
}