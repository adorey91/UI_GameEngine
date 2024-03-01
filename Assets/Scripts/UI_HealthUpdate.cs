using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthUpdate : MonoBehaviour
{
    [Header("HealthBar")]
    [SerializeField] private int maxHp;
    [SerializeField] private Image healthFill;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Gradient healthImageGrad;
    [SerializeField] private Image slider;
    [SerializeField] private TMP_Text Heal;
    [SerializeField] private TMP_Text Damage;
    private int curHp;

    [Header("Input Field")]
    [SerializeField] private TMP_InputField damageInput;
    [SerializeField] private TMP_InputField healInput;
    [SerializeField] int damageAmount;
    [SerializeField] int healAmount;

    private string damagePlaceholder;
    private string healPlaceholder;

    public void Start()
    {
        curHp = maxHp;
        healthText.text = $"{curHp} / {maxHp}";
        Damage.text = $"Hurt Player (-{damageAmount})";
        Heal.text = $"Heal Player ({healAmount})";

        damagePlaceholder = damageInput.placeholder.GetComponent<TextMeshProUGUI>().text;
        healPlaceholder = healInput.placeholder.GetComponent<TextMeshProUGUI>().text;
    }

    public void Update()
    {
        UpdateHealthUI();
    }

    public void UpdateDamageAmount()
    {

        if (int.TryParse(damageInput.text, out int parsedDamage))
        {
            damageAmount = parsedDamage;
            Damage.text = $"Hurt Player (-{damageAmount})";
        }
        else
            Debug.LogError("Failed to parse damage input as an integer.");
        damageInput.text = null;
    }

    public void UpdateHealAmount()
    {
        if (int.TryParse(healInput.GetComponent<TMP_InputField>().text, out int parsedHeal))
        {
            healAmount = parsedHeal;
            Heal.text = $"Heal Player ({healAmount})";
        }
        else
            Debug.LogError("Failed to parse heal input as an integer");

        healInput.text = null;
    }

    public void ApplyDamage()
    {
        HealthChange(-damageAmount);
    }

    public void ApplyHealing()
    {
        HealthChange(healAmount);
    }

    private void UpdateHealthUI()
    {
        healthSlider.value = (float)curHp / (float)maxHp;
        healthFill.fillAmount = (float)curHp / (float)maxHp;
        healthFill.color = healthImageGrad.Evaluate(healthFill.fillAmount);
        slider.color = healthImageGrad.Evaluate(healthSlider.value);
        healthText.text = $"{curHp} / {maxHp}";
    }

    private void HealthChange(int amount)
    {
        curHp += amount;
        curHp = Mathf.Clamp(curHp, 0, maxHp);
    }



}
