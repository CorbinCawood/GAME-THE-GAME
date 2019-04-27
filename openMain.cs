using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class openMain : MonoBehaviour
{

    public Button startButton;

    
    
    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(openMainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void openMainMenu()
    {

        SceneManager.LoadScene("Main Menu");
    }
}
