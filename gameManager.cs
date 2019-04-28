using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static GameObject mainCamera;
    public static float spawnX;
    public static float spawnY;
    public static Vector2 spawnCoordinates;
    public bool sceneLoaded;
    public bool singlePlayer;
    public Scene prevScene;
    public bool dead;
    public playerClass playerOne;
    public playerClass playerTwo;
    public GameObject P1;
    public GameObject P2;
    public GameObject healthBar;
    public bool hubLoaded;
    public bool slimeLoaded;
    public bool finalBossLoaded;
    public int numKills;
    
    //Initialize the player
    void Awake()
    {

        numKills = 0;
        dead = false;
        finalBossLoaded = false;
        DontDestroyOnLoad(this.gameObject);

        //Create new player when single player is selected
        singlePlayer = GameObject.Find("Button Manager").GetComponent<createGame>().singleDepressed;
        if (singlePlayer)
        {
            playerOne = new playerClass();
            playerOne.name = "playerOne";
            playerOne.playerType = GameObject.Find("Button Manager").GetComponent<createGame>().playerOneType.options[GameObject.Find("Button Manager").GetComponent<createGame>().playerOneType.value].text;
            playerOne.playerHealth = 5;
            playerOne.attackLevel = 0;
            playerOne.attackSpeed = 0;
            playerOne.defenseLevel = 0;
            
            
        }
  

        hubLoaded = false;
        slimeLoaded = false;
    }

    // Start is called before the first frame update
    void Start()
    {

        prevScene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {

        //update the current scene the player is in
        if(SceneManager.GetActiveScene().name != prevScene.name)
        {
            prevScene = SceneManager.GetActiveScene();
            if (SceneManager.GetActiveScene().name != "Game Over")
            {
                instantiateSingle();
            }

        }
        
        //If the player gets 20 kills, load the final boss scene.
        if (numKills >= 20 && !finalBossLoaded)
        {
            SceneManager.LoadScene("finalBoss");
            numKills = 0;
        }
        //If the player gets 30 kills and is in the boss scene, declare victory
        else if (numKills >= 30 && finalBossLoaded)
        {
            SceneManager.LoadScene("Victory");
        }
        
        //If the player has no health and is not dead yet, set them as dead and play death animation
        if (playerOne.playerHealth <= 0 && !dead)
        {

            dead = true;
            StartCoroutine(P1.GetComponent<spriteAnimator>().animateDeath());

            StartCoroutine(delayThenGO());
        }

    }

    //Set up the single player game. Instantiates the player.
    public void instantiateSingle()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");


        string defenseString;
        string playerTypeString;
        string pathToSprites;
        GameObject mainCam = GameObject.Find("Main Camera");
        if (singlePlayer)
        {
            float cameraPosX = mainCam.transform.position.x;
            float cameraPosY = mainCam.transform.position.y;
            P1.name = "P1";
            P1.tag = "Player";
            
            P1.transform.position = new Vector3(cameraPosX, cameraPosY, 0f);

            P1 = Resources.Load("PreFabs/Player") as GameObject;
            healthBar = Resources.Load("PreFabs/HealthBar") as GameObject;
            if (playerOne.playerType == "Mage")
            {
                P1.GetComponent<spriteAnimator>().playerType = 2;
            }
            else
            {
                P1.GetComponent<spriteAnimator>().playerType = 0;
            }

            spriteAnimator P1animator = P1.GetComponent<spriteAnimator>();

            playerTypeString = playerOne.playerType;
            defenseString = playerOne.defenseLevel.ToString();
            pathToSprites = playerTypeString + "/" + defenseString + "/";

            P1animator._attackNames = pathToSprites + "Attack";
            P1animator._idleNames = pathToSprites + "Idle";
            P1animator._walkNames = pathToSprites + "Walk";
            
            Instantiate(P1, new Vector3(mainCam.transform.position.x, mainCam.transform.position.y, 0.0f), Quaternion.identity);
            Instantiate(healthBar, new Vector3(0, 0, 0), Quaternion.identity);
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Enemy>()._target = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }

        
    }

    //Function called when player takes damage
    public void damagePlayer()
    {
        
        print("DAMAGE RECEIVED");
        playerOne.playerHealth -= 1;
    }

    //Called when the player is killed and the game ends
    public IEnumerator delayThenGO()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("Game Over");
    }

}
