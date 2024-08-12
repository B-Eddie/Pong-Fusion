using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (transform.position[1] < 3.7)
            {
                transform.position += new Vector3(0, moveSpeed, 0);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (transform.position[1] > -3.7)
            {
                transform.position += new Vector3(0, -moveSpeed, 0);
            }
        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = touch.position;
            float screenWidth = Screen.width;

            if (touchPosition.x < screenWidth / 2)
            {
                transform.position += new Vector3(0, moveSpeed, 0);
            }
            else
            {
                transform.position += new Vector3(0, -moveSpeed, 0);
            }
        }
    }
}
