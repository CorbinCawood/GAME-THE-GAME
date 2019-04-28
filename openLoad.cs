﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class openLoad : MonoBehaviour
{

    public Button loadMenu;
    // Start is called before the first frame update. Loads the menu scene when the menu button is clicked.
    void Start()
    {
        loadMenu.onClick.AddListener(loadLoad);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Function for loading the menu
    void loadLoad()
    {
        SceneManager.LoadScene("Load Menu");
    }
}
