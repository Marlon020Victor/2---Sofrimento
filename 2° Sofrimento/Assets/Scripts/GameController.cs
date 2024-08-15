using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public int TotalScore;
    public TextMeshProUGUI ScoreText;
    public static GameController instance;

    public GameObject GameOver;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        ScoreText.text = TotalScore.ToString();
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
