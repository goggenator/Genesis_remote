using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltEnemyController : EnemyController
{
    [SerializeField] bool walking = false;
    [SerializeField]float waitUntilChangeDirection;
    private void Awake()
    {
        targetPosition = Vector2.zero;
        movement = GetComponent<MovementManager>();
    }
    public virtual void Update()
    {
        if(!walking)
        {
            StartCoroutine(WaitForDirection());
        }
        movement.SetDirection(targetPosition);
    }

    void ChangeDirection()
    {
        Vector2 distance = new Vector2(Game.I.GetPlayerPosition().x - transform.position.x, Game.I.GetPlayerPosition().y - transform.position.y);
        if ((distance.x > distance.y && distance.x > 0 && distance.y > 0) || (distance.x < distance.y && distance.x < 0 && distance.y < 0))
        {
            distance.y = 0;
        }
        else
        {
            distance.x = 0;
        }
        distance.Normalize();
        targetPosition = distance;
    }

    IEnumerator WaitForDirection()
    {
        walking = true;
        yield return new WaitForSeconds(waitUntilChangeDirection);
        ChangeDirection();
        walking = false;
    }
}
