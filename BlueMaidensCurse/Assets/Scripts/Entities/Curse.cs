﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curse : MonoBehaviour
{
    [SerializeField] float curseDamage;
    [SerializeField] float curseIncrease;
    [SerializeField] float curseMaxValue;
    [SerializeField] float curseResetValue;
    HealthManager HP;
    bool activated = false;

    public void Awake()
    {
        HP = GetComponent<HealthManager>();
    }

    public void Update()
    {
        if(activated)
        {
            HP.OnHit(curseDamage * Time.deltaTime);
        }
    }
    public void IncreaseCurse()
    {
        if(curseDamage <= curseMaxValue)
        {
            curseDamage *= curseIncrease;
        }
    }
    public void ResetCurse()
    {
        curseDamage = curseResetValue;
        HP.OnRestoreHP();
    }
    public void ActivateCurse()
    {
        activated = true;
    }
}
