using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleMovement : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {

            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(moveHorizontal*speed*Time.deltaTime, moveVertical*speed*Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector2(0.0f, 0.0f);
        }
    }
}
