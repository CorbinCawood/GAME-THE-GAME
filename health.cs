using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

//Defines the health behaviour

public class health : MonoBehaviour
{

    public GameObject GM;
    public Sprite[] healthTicks;
    public Text textObj;
    
    
    // Start is called before the first frame update. Initializes the health component
    void Start()
    {
        healthTicks = Resources.LoadAll<Sprite>("HP/");
        GM = GameObject.Find("gmPrefab(Clone)");

    }

    // Update is called once per frame. Updates the health each frame to keep up with any changes
    void Update()
    {


        int index = GM.GetComponent<gameManager>().playerOne.playerHealth;

        gameObject.GetComponent<Image>().overrideSprite = healthTicks[index];



    }
}
