﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraugController : EnemyController
{
    private void Awake()
    {
        movement = GetComponent<MovementManager>();
    }
    public virtual void Update()
    {
        targetPosition = new Vector2(Game.I.GetPlayerPosition().x - transform.position.x, Game.I.GetPlayerPosition().y - transform.position.y); targetPosition.Normalize();
        movement.SetDirection(targetPosition);
    }
}