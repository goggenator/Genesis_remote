﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    protected MovementManager movement;
    bool isDead = false;
    protected HealthManager HP;
    [SerializeField] string deathSound;

    public void OnHit(int damage)
    {
        if(HP.GetHP() - damage > 0)
        {
            HP.OnHit(damage);
            GetComponentInChildren<Animator>().SetTrigger("WitchDamage");
        }
        else
        {
            movement.SetFrozen(true);
            GetComponentInChildren<Animator>().SetTrigger("IsDead");
            FindObjectOfType<AudioManager>().Play(deathSound);
        }
    }

    public void SetIsDead()
    {
        isDead = true;
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
