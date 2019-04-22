using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartOptions : MonoBehaviour
{
    public bool hasBeenClicked = false;

    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
    }    

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            hasBeenClicked = true;
            panel.SetActive(true);
        });
    }
}
