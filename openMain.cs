using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class openMain : MonoBehaviour
{

    public Button startButton;

    
    
    // Start is called before the first frame update. Loads the main menu scene when the main menu button is pressed.
    void Start()
    {
        startButton.onClick.AddListener(openMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Function for loading the main menu scene.
    void openMainMenu()
    {

        SceneManager.LoadScene("Main Menu");
    }
}
