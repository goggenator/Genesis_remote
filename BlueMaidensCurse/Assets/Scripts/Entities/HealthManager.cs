using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int MaxHP;
    [SerializeField] float HP;

    public void InitializeHealth(float givenHP)
    {
        HP = givenHP;
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
    public void OnHeal(int heal)
    {
        if(HP + heal <= MaxHP)
        {
            HP += heal;
        }
        else
        {
            HP = MaxHP;
        }
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
