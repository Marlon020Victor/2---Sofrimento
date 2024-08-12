using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public int TotalScore;
    public TextMeshProUGUI ScoreText;
    public static GameController instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void UpdateScoreText()
    {
        ScoreText.text = TotalScore.ToString();
    }
}
