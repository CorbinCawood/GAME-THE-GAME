using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    
    // Start is called before the first frame update
    public GameObject cv;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Start Options").GetComponent<StartOptions>().hasBeenClicked )
        {
            gameObject.GetComponent<Button>().interactable = true;
        
        }
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            cv.SetActive(false);
            var player = GameObject.FindWithTag("Player");
            player.GetComponent<simpleMovement>().speed = 150;
           
        });
        
    }
}
