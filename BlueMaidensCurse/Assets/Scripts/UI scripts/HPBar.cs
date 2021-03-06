﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public HealthManager HP = null;
    [SerializeField] Image HealthBar = null;
    public Text HealthText;
    private float currentFill;
    public float BarChangeSpeed;

    private void Update()
    {
        UpdateText();
        UpdateHealthBarLength();
        UpdateHealthBarColor();
    }
    void UpdateText()
    {
        if (HealthText != null)
        {
            HealthText.text = Mathf.RoundToInt(HP.GetHP()) + "/" + Mathf.RoundToInt(HP.GetMaxHP());
        }
    }
    private void UpdateHealthBarLength()
    {
        currentFill = HP.GetHPPercentage();
        if (currentFill != HealthBar.fillAmount)
        {
            HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, currentFill, Time.deltaTime * BarChangeSpeed);
        }
    }
    private void UpdateHealthBarColor()
    {
        HealthBar.color = new Color(1, 0, 1 * (1 - HP.GetHPPercentage()), 1);
    }
}
