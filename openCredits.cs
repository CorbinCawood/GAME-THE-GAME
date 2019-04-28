using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class openCredits : MonoBehaviour
{

    public Button credits;
    
    // Start is called before the first frame update. Loads the credits scene when the credits button is pushed
    void Start()
    {
        credits.onClick.AddListener(loadCredits);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Function for loading the credits.
    void loadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
