using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangaer : MonoBehaviour {
    public static GameMangaer instance;
    public bool gameOver;
     void Awake()
    {
     if(instance == null)
        {
            instance = this;
        }   
    }
    // Use this for initialization
    void Start () {
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   public  void StartGame()
    {
        UiManager.instance.GameStart();
        ScoreManager.instance.startscore();
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().startspawningplatforms();
    }
   public  void Gameover()
    {
        UiManager.instance.GameOver();
        ScoreManager.instance.stopscore();
        gameOver = true;
    }
}
