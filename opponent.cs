using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public Transform ball;
    private Rigidbody2D rb;
    public float moveSpeed = 5f;
    
    private float startX; // To store the initial X position

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startX = transform.position.x; // Store the initial X position
    }

    private void Update()
    {
        // Calculate the direction towards the ball
        Vector2 direction = new Vector2(0, ball.position.y - transform.position.y).normalized;

        // Move the opponent towards the ball
        rb.velocity = direction * moveSpeed;

        // Lock the X position
        transform.position = new Vector3(startX, transform.position.y, transform.position.z);
    }
}
