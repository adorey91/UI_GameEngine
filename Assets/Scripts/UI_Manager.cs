using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UI_Manager : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] private TextMeshProUGUI scoreAmount;
    private int score = 0;

    [Header("RGBA Settings")]
    [SerializeField] private Image image;
    [SerializeField]private Slider redSlider;
    [SerializeField]private Slider greenSlider;
    [SerializeField]private Slider blueSlider;
    [SerializeField]private Slider alphaSlider;

    [Header("Collectable Settings")]
    [SerializeField] private GameObject collectableImage;
    [SerializeField] private Button hideShowButton;
    private bool isHidden;
    private TextMeshProUGUI buttonText;



    void Start()
    {
        scoreAmount.text = "Score: " + score.ToString();
        
        redSlider.value = 1;
        greenSlider.value = 1;
        blueSlider.value = 1;
        alphaSlider.value = 1;

        isHidden = false;
        buttonText = hideShowButton.GetComponentInChildren<TextMeshProUGUI>();

    }

    public void ScoreChange(int value)
    {
        if (value == 0)
            score = 0;
        else
            score += value;
        score = Mathf.Clamp(score, 0, 999999999);
        scoreAmount.text = "Score: " + score.ToString("#,##0");
    }

    public void RandomScore()
    {
        int random;
        do
        {
            random = Random.Range(-999999999, 999999999);
        }while (random == 0);

        Debug.Log(random.ToString());
        ScoreChange(random);
    }

    public void ColorChange()
    {
        image.color = new UnityEngine.Color(redSlider.value, greenSlider.value, blueSlider.value, alphaSlider.value);
    }

    public void HideImage()
    {
        isHidden = !isHidden;

        if(isHidden)
        {
            buttonText.text = "Show Image";
            collectableImage.SetActive(false);
        }
        else
        {
            buttonText.text = "Hide Image";
            collectableImage.SetActive(true);
        }
       
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Application");
    }
}
