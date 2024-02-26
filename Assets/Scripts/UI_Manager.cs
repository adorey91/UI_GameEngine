using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreAmount;

    private int score = 0;
   

    void Start()
    {
        scoreAmount.text = "Score: " + score.ToString();
    }

    public void ScoreChange(int value)
    {
        if (value == 0)
            score = 0;
        else
            score += value;

        
        if(score <= 0)
            score = 0;
        if (score > 999999999)
            score = 999999999;

        scoreAmount.text = "Score: " + score.ToString("#,##0");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Application");
    }
}
