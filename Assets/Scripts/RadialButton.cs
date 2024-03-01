using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialButton : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Button button;
    [SerializeField] float fillTimeInSeconds;

    [SerializeField] private float fillStartTime;
    [SerializeField] private bool isFilling;
    [SerializeField] private float fillProgress;

    public void Start()
    {
        // initiaLizing fillStarttime
        fillStartTime = Time.time;
        isFilling = false;
    }

    public void Update()
    {
        image = button.GetComponent<Image>();
        if (isFilling)
        {
            fillProgress = (Time.time - fillStartTime) / fillTimeInSeconds;
            fillProgress = Mathf.Clamp01(fillProgress);

            image.fillAmount = fillProgress;

            
            if (fillProgress >= 1f)
            {
                isFilling = false;
                button.interactable = true;
            }
        }
    }

    public void StartFilling()
    {
        fillStartTime = Time.time;
        image.fillAmount = 0f; // Reset fill amount
        isFilling = true;
        button.interactable = false;
    }
}
