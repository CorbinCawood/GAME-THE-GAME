using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numPlayerDropdown : MonoBehaviour
{
    public Dropdown numPlayers;
    public Dropdown player2;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (numPlayers.value == 1 )
        {
            player2.interactable = true;
        }
    }
}
