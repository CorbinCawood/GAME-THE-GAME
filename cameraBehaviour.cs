using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cameraBehaviour : MonoBehaviour
{

    public GameObject Player;

    private Vector3 offset;


    void Awake()
    {

        Player = GameObject.Find("P1(Clone)");
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("P1(Clone)");
        Vector3 playerPos = Player.transform.position;
        offset = transform.position - playerPos;

    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.Find("P1(Clone)");
        float playerX = Player.transform.position.x;
        float playerY = Player.transform.position.y;
        transform.position = new Vector3(playerX, playerY, transform.position.z);
    }
}
