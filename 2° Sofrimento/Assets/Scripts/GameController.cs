using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int TotalScoreC;
    public int TotalScoreB;
    public TextMeshProUGUI ScoreTextC;
    public TextMeshProUGUI ScoreTextB;
    public static GameController instance;

    public GameObject GameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        ScoreTextC.text = TotalScoreC.ToString();
        ScoreTextB.text = TotalScoreB.ToString();
    }

    public void ShowGameOver()
    {
        GameOver.SetActive(true);
    }

    public void Restart(string LevelName)
    {
        SceneManager.LoadScene(LevelName);
    }
}
