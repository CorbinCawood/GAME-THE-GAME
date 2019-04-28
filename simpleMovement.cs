using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

//Defines the movement of characters in the game.

public class simpleMovement : MonoBehaviour
{

    public float speed;

    private Rigidbody2D rb;
    private TreeGraph tg;
    // Start is called before the first frame update
    void Start()
    {    
        tg = new TreeGraph();
        rb = GetComponent<Rigidbody2D>();
        tg.BuildEdges(new Tuple<string, string>("a","b"),
            new Tuple<string, string>("a","c"),
            new Tuple<string, string>("b","c"),
            new Tuple<string, string>("d","c"),
            new Tuple<string, string>("e","f"),
            new Tuple<string, string>("e","f")
        );
        Console.WriteLine("backedges");
        foreach (var kv in tg.nodeLookup)
        {
            string output="";
            output += kv.Key + ":";
            foreach (var edge in kv.Value.back_edges)
            {
                output+=edge+",";
            }

            Debug.Log(output);
        }
    }

    // Update is called once per frame. Updates horizontal, verticle, and velocity.
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
