using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class openConfig : MonoBehaviour
{

    public Button newGame;
    // Start is called before the first frame update. Loads the configuration menu when the new game button is clicked.
    void Start()
    {
        newGame.onClick.AddListener(loadConfig);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function for loading the Config Menu scene
    void loadConfig()
    {
        SceneManager.LoadScene("Config Menu");
    }
}
