using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        progress.text = $"{(collectAmount /  totalAmount) * 100}%";
        progressSlider.value = collectAmount;
    }
}
