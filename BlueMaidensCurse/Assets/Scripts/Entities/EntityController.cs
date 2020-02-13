using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    protected MovementManager movement;
    [SerializeField] HealthManager HP;

    public void OnHit(int damage)
    {
        if(HP.GetHP() - damage > 0)
        {
            HP.OnHit(damage);
        }
        else
        {
            movement.OnDeath();
        }
    }
  
}
