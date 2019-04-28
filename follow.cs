using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This is where the follow behavior is defined for the enemies when they are within range of the hero.

public class follow : MonoBehaviour
{
    public float speed;

    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        //Find the player
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Update the position each frame
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
