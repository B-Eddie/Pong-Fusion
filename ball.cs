using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Add this namespace for the Text component

public class Ball : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    public Text Balle; // Make sure this is assigned in the Inspector
    private List<int> score_num = new List<int> { 0, 0 };
    private float speedmultiplier = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        // Randomly decide whether to launch the ball left or right
        float xDirection = Random.Range(0, 2) == 0 ? -1 : 1;
        float yDirection = Random.Range(0, 2) == 0 ? -1 : 1;

        Vector2 direction = new Vector2(xDirection, yDirection).normalized;
        rb.velocity = direction * speed;
        speedmultiplier = 1;
    }

    void Update()
    {
        // Update the text component with the current score
        if (Balle != null)
        {
            Balle.text = string.Join(":", score_num);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reflect the ball's velocity based on the collision normal
        Vector2 newVelocity = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);

        // Maintain the original speed after reflection
        rb.velocity = newVelocity.normalized * speed * speedmultiplier;

        if (collision.gameObject.name == "wall1")
        {
            score_num[1]++;
            ResetBall();
        }
        else if (collision.gameObject.name == "wall3")
        {
            score_num[0]++;
            ResetBall();
        }

        speedmultiplier += 0.1f;
        Debug.Log(speedmultiplier);
    }

    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        speedmultiplier = 1f;
        LaunchBall();
    }
}
