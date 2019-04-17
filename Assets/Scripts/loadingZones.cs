using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingZones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (gameObject.name)
        {
            
            case "Slime Zone":

                SceneManager.LoadScene("Slime Dungeon");
                break;
            
            case "Skeleton Zone":
                SceneManager.LoadScene("Skeleton Dungeon");
                break;
            
            case "Goblin Zone":

                SceneManager.LoadScene("Goblin Dungeon");
                break;
            
            case "Hub Zone":

                SceneManager.LoadScene("Hub Room");
                break;
        }
    }
}
