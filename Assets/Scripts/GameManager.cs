﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    public Scene scene;

    public static GameManager instance = null;
    private static readonly object padlock = new object();

    //all player control device
    //public PlayerData player1PlayerData { get; set; }
    //public PlayerData player2PlayerData { get; set; }
    //public PlayerData player3PlayerData { get; set; }
    //public PlayerData player4PlayerData { get; set; }
    public static Dictionary<int, PlayerData> playerDataDict = new Dictionary<int, PlayerData>();

    GameManager()
    {

    }

    public static GameManager Instance
    {
        get
        {
            //remove lock at this time
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            
        }
    }

    public void Awake()
    {
        
        scene = SceneManager.GetActiveScene();

        if (scene.name == "Menu")
        {
            FindObjectOfType<AudioManager>().Play("mainMenuMusic");
            //FindObjectOfType<AudioManager>().Play("birds");

        }
        else if (scene.name == "Level1")
        {
            FindObjectOfType<AudioManager>().Play("drawingSceneMusic");
        }
        else if (scene.name == "Victory")
        {
            FindObjectOfType<AudioManager>().Stop("drawingSceneMusic");
            FindObjectOfType<AudioManager>().Play("victory");
        }
    }


    public static void GameOver()
    {

        FindObjectOfType<AudioManager>().Stop("bossBattle");
    
        //losing music
        FindObjectOfType<AudioManager>().Play("defeat");
        //death condition
        Initiate.Fade("GameOver", Color.black, 0.6f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        if (scene.name == "SelectCharacter")
        {
            //FindObjectOfType<AudioManager>().Stop("birds");
            FindObjectOfType<AudioManager>().Stop("mainMenuMusic");
            FindObjectOfType<AudioManager>().Play("playAgain");
            Initiate.Fade("POC_Boss", Color.white, 0.6f);
        }
        else if(scene.name == "Menu")
        {
            Initiate.Fade("SelectCharacter", Color.white, 1.0f);

        }
        else
        {
            FindObjectOfType<AudioManager>().Play("playAgain");
            Initiate.Fade("POC_Boss", Color.white, 0.6f);
        }


    }

    public void CharacterScene()
    {

        FindObjectOfType<AudioManager>().Play("playAgain");
        Initiate.Fade("SelectCharacter", Color.white, 0.3f);
        //FindObjectOfType<AudioManager>().Play("bossBattle");
    }

    public void exitGame(){
        Application.Quit();
    }

    // public void setPlayerDic(Dictionary<int, PlayerData> playerDic){
    //     this.playerDataDict = playerDic;
    // }

    // public Dictionary<int, PlayerData> getPlayerDic(){
    //     return playerDataDict;
    // }
}
