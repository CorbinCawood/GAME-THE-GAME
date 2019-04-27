using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{

    public GameObject GM;
    public Sprite[] healthTicks;
    public Text textObj;
    
    
    // Start is called before the first frame update
    void Start()
    {
        healthTicks = Resources.LoadAll<Sprite>("HP/");
        GM = GameObject.Find("gmPrefab(Clone)");

    }

    // Update is called once per frame
    void Update()
    {


        int index = GM.GetComponent<gameManager>().playerOne.playerHealth;

        gameObject.GetComponent<Image>().overrideSprite = healthTicks[index];



    }
}
