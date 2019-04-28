using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//This is the code for creating a new game instance.

public class createGame : MonoBehaviour
{

    public Button singlePlayer;
    public Button twoPlayer;
    public Button backToMain;
    public Dropdown playerOneType;
    public Dropdown playerTwoType;
    public Button startGame;
    public GameObject GM;
    public bool singleDepressed;

    public bool duelDepressed;
    // Start is called before the first frame update
    void Start()
    {
        
       singlePlayer.onClick.AddListener(singleSelected);
       twoPlayer.onClick.AddListener(duelSelected);
       backToMain.onClick.AddListener(loadMain);
       startGame.onClick.AddListener(loadGame);
       playerOneType.image.color = Color.black;
       playerTwoType.image.color = Color.black;
       startGame.image.color = Color.black;
       singleDepressed = false;
       duelDepressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Single player selected, adjust menu for one player
        if (singleDepressed && !duelDepressed)
        {
            playerOneType.image.color = Color.white;
            playerTwoType.image.color = Color.black;
            playerOneType.interactable = true;
            playerTwoType.interactable = false;
            startGame.image.color = Color.white;
            startGame.interactable = true;
        }
        //Two player selected, adjust menu for both players. Make buttons for player two interactable
        else if (!singleDepressed && duelDepressed)
        {
            playerOneType.image.color = Color.white;
            playerTwoType.image.color = Color.white;
            playerOneType.interactable = true;
            playerTwoType.interactable = true;
            startGame.image.color = Color.white;
            startGame.interactable = true;
        }
        
        //If number of players not selected, none of the buttons are interactable
        else
        {
            playerOneType.image.color = Color.black;
            playerTwoType.image.color = Color.black;
            playerOneType.interactable = false;
            playerTwoType.interactable = false;
            startGame.interactable = false;
            startGame.image.color = Color.black;
        }
    }

    //Function for single player selected. Sets up the menu for single player.
    void singleSelected()
    {

        if (singleDepressed == false)
        {
            singlePlayer.image.color = singlePlayer.colors.pressedColor;
            singleDepressed = true;

            if (duelDepressed == true)
            {
                twoPlayer.image.color = twoPlayer.colors.normalColor;
                duelDepressed = false;
            }
        }
        else
        {
            singlePlayer.image.color = singlePlayer.colors.normalColor;
            singleDepressed = false;
        }
    }

    //Function for when two player is selected. Sets up the menue for two players.
    void duelSelected()
    {

        if (duelDepressed == false)
        {
            twoPlayer.image.color = twoPlayer.colors.pressedColor;
            duelDepressed = true;

            if (singleDepressed == true)
            {
                singlePlayer.image.color = singlePlayer.colors.normalColor;
                singleDepressed = false;
            }
        }
        else
        {
            twoPlayer.image.color = twoPlayer.colors.normalColor;
            duelDepressed = false;
        }
    }
    
    //Loads the main menu
    void loadMain()
    {
        SceneManager.LoadScene("Main Menu");
    }

    //Loads the starting room of the dungeon and initiates the game.
    void loadGame()
    {
        
        Instantiate(GM, new Vector3(0f, 0f, 0f), Quaternion.identity);

        SceneManager.LoadScene("Hub Room");
    }
}
