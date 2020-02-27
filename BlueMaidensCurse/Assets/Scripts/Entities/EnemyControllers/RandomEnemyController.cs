using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyController : EnemyController
{
    [SerializeField] Direction direction;
    [SerializeField] bool walking = false;
    [SerializeField] float waitUntilChangeDirection;
    private void Awake()
    {
        movement = GetComponent<MovementManager>();
        HP = GetComponentInChildren<HealthManager>();
        HP.InitializeHealth(HP.GetMaxHP());
        targetPosition = Vector2.zero;
    }
    public virtual void Update()
    {
        if (!walking)
        {
            StartCoroutine(WaitForDirection());
        }
        switch (direction)
        {
            case Direction.up:
                targetPosition = new Vector2(0, 1);
                break;
            case Direction.down:
                targetPosition = new Vector2(0, -1);
                break;
            case Direction.left:
                targetPosition = new Vector2(-1, 0);
                break;
            case Direction.right:
                targetPosition = new Vector2(1, 0);
                break;
            case Direction.none: break;
            default: break;
        }
        movement.SetDirection(targetPosition);
    }

    Direction ChangeDirection()
    {
        return (Direction)Random.Range(0, 3);
    }

    IEnumerator WaitForDirection()
    {
        walking = true;
        yield return new WaitForSeconds(waitUntilChangeDirection);
        direction = ChangeDirection();
        walking = false;
    }
}
