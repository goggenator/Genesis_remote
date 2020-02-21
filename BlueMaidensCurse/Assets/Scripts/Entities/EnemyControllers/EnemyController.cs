using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    up = 0,
    down = 1,
    left = 2,
    right = 3,
    none = 4
}

public class EnemyController : EntityController
{
    protected Vector2 targetPosition;
}
