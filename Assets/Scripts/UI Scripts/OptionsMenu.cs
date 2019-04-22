using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public  GameObject panel ;
    private Dropdown player2;
    
    void Start()
    {
        panel = GameObject.Find("Options Menu");
    panel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
