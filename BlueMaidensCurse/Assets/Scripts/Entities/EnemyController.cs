using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    MovementManager movement;
    Vector2 targetPosition;
    [SerializeField] float speed;
    private void Awake()
    {
        movement = GetComponent<MovementManager>();
    }
    public virtual void FixedUpdate()
    {
        targetPosition = new Vector2(Game.I.GetPlayerPosition().x - transform.position.x, Game.I.GetPlayerPosition().y - transform.position.y); targetPosition.Normalize();
        movement.Move(targetPosition * speed * Time.deltaTime);
    }
}
