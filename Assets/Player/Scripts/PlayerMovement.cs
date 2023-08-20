using UnityEngine;
using Unity.Mathematics;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D RigidBody2d;

    public float speed;

    public float aceletarion;
    public float slowdown;

    // Start is called before the first frame update
    void Start()
    {
        RigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    private Vector2 persistentDirection;
    private float currentSpeed = 0;

    private void MovePlayer()
    {
        Vector2 arrowsDirections = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        currentSpeed = arrowsDirections != Vector2.zero ? currentSpeed += aceletarion : currentSpeed -= slowdown;

        currentSpeed = math.clamp(currentSpeed, 0, speed);

        if(arrowsDirections != Vector2.zero)
        {
            persistentDirection = arrowsDirections;
        }

        RigidBody2d.velocity = persistentDirection * currentSpeed;
    }
}