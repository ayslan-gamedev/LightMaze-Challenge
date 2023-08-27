using UnityEngine;
using Unity.Mathematics;
using TMPro;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D RigidBody2d;

    [SerializeField] private PlayerAtributts playerAtributts;

    public PlayerAtributts PlayerAtributts => playerAtributts;

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
    public float CurrentSpeed;

    private void MovePlayer()
    {
        Vector2 arrowsDirections = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        CurrentSpeed = arrowsDirections != Vector2.zero ? CurrentSpeed += playerAtributts.aceletarion : CurrentSpeed -= playerAtributts.slowdown;

        CurrentSpeed = math.clamp(CurrentSpeed, 0, playerAtributts.speed);

        if(arrowsDirections != Vector2.zero)
        {
            persistentDirection = arrowsDirections;
        }

        RigidBody2d.velocity = persistentDirection * CurrentSpeed;
    }
}

[System.Serializable]
public struct PlayerAtributts {
    public float speed;
    public float aceletarion;
    public float slowdown;
}