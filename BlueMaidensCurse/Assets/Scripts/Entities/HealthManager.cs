using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] int MaxHP;
    [SerializeField] int HP;
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
    public void OnRestoreHP()
    {
        HP = MaxHP;
    }
    public int GetHP()
    {
        return HP;
    }
}
