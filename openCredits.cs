using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class openCredits : MonoBehaviour
{

    public Button credits;
    
    // Start is called before the first frame update
    void Start()
    {
        credits.onClick.AddListener(loadCredits);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
