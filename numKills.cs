using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class numKills : MonoBehaviour
{


    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text =
            GameObject.Find("gmPrefab(Clone)").GetComponent<gameManager>().numKills.ToString();
    }
}
