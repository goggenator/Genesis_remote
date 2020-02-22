using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraugController : EnemyController
{
    public void Awake()
    {
        movement = GetComponent<MovementManager>();
        HP = GetComponentInChildren<HealthManager>();
    }
    public virtual void Update()
    {
        targetPosition = new Vector2(Game.I.GetPlayerPosition().x - transform.position.x, Game.I.GetPlayerPosition().y - transform.position.y); targetPosition.Normalize();
        movement.SetDirection(targetPosition);
        HP = GetComponentInChildren<HealthManager>();
    }
}
