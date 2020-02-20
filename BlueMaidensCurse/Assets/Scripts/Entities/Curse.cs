using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curse : MonoBehaviour
{
    [SerializeField] float curseDamage = 0.01f;
    HealthManager HP;

    public void Awake()
    {
        HP = GetComponent<HealthManager>();
    }

    public void Update()
    {
        HP.OnHit(curseDamage * Time.deltaTime);
    }
    public void IncreaseCurse()
    {
        curseDamage *= 1.25f;
    }
    public void ResetCurse()
    {
        curseDamage = 0.01f;
        HP.OnRestoreHP();
    }
}
