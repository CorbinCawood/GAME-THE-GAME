using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Defines the "Game Over" behaviour

public class gameOver : MonoBehaviour
{


    public Button backToTitle;
    // Start is called before the first frame update. Sends player back to title screen when clicked.
    void Start()
    {

        backToTitle.onClick.AddListener(returnToTitle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Loads the title screen
    void returnToTitle()
    {
        Destroy(GameObject.Find("gmPrefab(Clone)"));

        SceneManager.LoadScene("Title Screen");
    }

}
