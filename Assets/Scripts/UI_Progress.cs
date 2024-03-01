using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class UI_Progress : MonoBehaviour
{
    [SerializeField] private int collectAmount;
    [SerializeField] private int totalAmount;
    [SerializeField] private float percentage;
    [SerializeField] private TMP_Text progress;
    [SerializeField] private Slider progressSlider;
    [SerializeField] private Gradient Gradient;

    [SerializeField] private Button collectCoin;
    [SerializeField] private Button stealCoin;

    private void Start()
    {
        collectAmount = 0;
        progress.text = $"{Math.Ceiling(((float)collectAmount / (float)totalAmount) * 100)}%";
        progressSlider.value = (float)collectAmount / (float)totalAmount;
        ButtonInteract();
    }

    public void Update()
    {
        progress.text = $"{Math.Ceiling(((float)collectAmount / (float)totalAmount) * 100)}%";
        progressSlider.value = (float)collectAmount / (float)totalAmount;
        ButtonInteract();
    }

    public void RemoveCoin(int amount)
    {
        collectAmount -= amount;
        if (collectAmount <= 0)
            collectAmount = 0;
    }

    public void AddCoin(int amount)
    {
        collectAmount += amount;
        if (collectAmount >= totalAmount)
            collectAmount = totalAmount;
    }

    private void ButtonInteract()
    {
        if (collectAmount <= 0)
            stealCoin.interactable = false;
        if (collectAmount >= totalAmount)
            collectCoin.interactable = false;
        else
        {
            stealCoin.interactable = true;
            collectCoin.interactable = true;
        }
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
