using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class openTitle : MonoBehaviour
{

    public Button title;
    // Start is called before the first frame update
    void Start()
    {
        title.onClick.AddListener(loadTitle);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadTitle()
    {
        SceneManager.LoadScene("Title Screen");
    }
}
