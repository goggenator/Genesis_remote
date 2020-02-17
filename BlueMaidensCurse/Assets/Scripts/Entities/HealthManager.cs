using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int MaxHP;
    [SerializeField] float HP;
    public void Awake()
    {
        HP = MaxHP;
    }
    public void OnHit(int damage)
    {
        if(HP > 0)
        {
            HP -= damage;
        }
    }
    public void OnHit(float damage)
    {
        if (HP > 0)
        {
            HP -= damage;
        }
    }
    public void OnRestoreHP()
    {
        HP = MaxHP;
    }
    public float GetHP()
    {
        return HP;
    }
    public int GetMaxHP()
    {
        return MaxHP;
    }
    public float GetHPPercentage()
    {
        return HP / MaxHP;
    }
}
