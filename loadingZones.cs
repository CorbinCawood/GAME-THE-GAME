using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadingZones : MonoBehaviour
{

    public bool visitedSlime;

    public bool visitedSkeleton;
    
    public bool visitedGoblin;
    // Start is called before the first frame update. Initiate everything as unvisited.
    void Start()
    {
        GameObject gameManager = GameObject.Find("Game Manager");

        visitedSlime = false;
        visitedSkeleton = false;
        visitedGoblin = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Loads the correct scene based on where the player goes.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && other.GetType() != typeof(CircleCollider2D))
        {
            //Switch statement to choose which scene to load based on player movement
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

                case "fromGoblin":


                    SceneManager.LoadScene("hubFromGoblin");

                    break;

                case "fromSkeleton":

                    SceneManager.LoadScene("hubFromSkeleton");

                    break;

                case "fromSlime":

                    SceneManager.LoadScene("hubFromSlime");

                    break;
            }
        }
    }
}
