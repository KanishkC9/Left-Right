using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {
    public static UiManager instance;
    public GameObject ZigZagPanel;
    public GameObject gameoverpanel;
    public Text score;
    public Text highscore1;
    public Text highscore2;
    public GameObject tapText;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        highscore1.text = PlayerPrefs.GetInt("highscore").ToString();
    }
    public void GameStart()
    {   
      
        tapText.SetActive(false);
        ZigZagPanel.GetComponent<Animator>().Play("Panelup");
    }
	
    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt ("score").ToString();
        highscore2.text = PlayerPrefs.GetInt("highscore").ToString();
        gameoverpanel.SetActive(true);
    }
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
