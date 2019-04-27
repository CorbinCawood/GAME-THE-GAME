using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
        if (singleDepressed && !duelDepressed)
        {
            playerOneType.image.color = Color.white;
            playerTwoType.image.color = Color.black;
            playerOneType.interactable = true;
            playerTwoType.interactable = false;
            startGame.image.color = Color.white;
            startGame.interactable = true;
        }
        else if (!singleDepressed && duelDepressed)
        {
            playerOneType.image.color = Color.white;
            playerTwoType.image.color = Color.white;
            playerOneType.interactable = true;
            playerTwoType.interactable = true;
            startGame.image.color = Color.white;
            startGame.interactable = true;
        }
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

    void loadMain()
    {
        SceneManager.LoadScene("Main Menu");
    }

    void loadGame()
    {
        
        Instantiate(GM, new Vector3(0f, 0f, 0f), Quaternion.identity);

        SceneManager.LoadScene("Hub Room");
    }
}
