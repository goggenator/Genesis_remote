using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    protected MovementManager movement;
    bool isDead = false;
    [SerializeField] HealthManager HP;

    public void OnHit(int damage)
    {
        if(HP.GetHP() - damage > 0)
        {
            HP.OnHit(damage);
        }
        else
        {
            isDead = true;
        }
    }
    public bool GetIsDead()
    {
        return isDead;
    }
    public void OnDeath()
    {
        movement.OnDeath();
    }
}
