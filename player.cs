using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            if (transform.position[1] < 3.7) {
                transform.position += new Vector3(0, 0.005f, 0);
            }
        } else if (Input.GetKey(KeyCode.S)) {
            if (transform.position[1] > -3.7) {
                transform.position += new Vector3(0, -0.005f, 0);
            }
        }
    }
}
