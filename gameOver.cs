using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{


    public Button backToTitle;
    // Start is called before the first frame update
    void Start()
    {

        backToTitle.onClick.AddListener(returnToTitle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void returnToTitle()
    {
        Destroy(GameObject.Find("gmPrefab(Clone)"));

        SceneManager.LoadScene("Title Screen");
    }

}
