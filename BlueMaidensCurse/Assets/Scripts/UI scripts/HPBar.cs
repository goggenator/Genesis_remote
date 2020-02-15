using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public HealthManager HP;
    [SerializeField] Image HealthBar;
    public Text HealthText;
    private float currentFill;
    public float BarChangeSpeed;

    private void Update()
    {
        UpdateText();
        UpdateHealthBar();
    }
    void UpdateText()
    {
        if (HealthText != null)
        {
            HealthText.text = Mathf.RoundToInt(HP.GetHP()) + "/" + Mathf.RoundToInt(HP.GetMaxHP());
        }

    }
    private void UpdateHealthBar()
    {
        currentFill = HP.GetHPPercentage();
        if (currentFill != HealthBar.fillAmount)
        {
            HealthBar.fillAmount = Mathf.Lerp(HealthBar.fillAmount, currentFill, Time.deltaTime * BarChangeSpeed);
        }
    }
}
