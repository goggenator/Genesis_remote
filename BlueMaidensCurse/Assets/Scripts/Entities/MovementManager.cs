using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour //This is the script that should be used for everything that moves!
{
    Rigidbody2D myBody;
    [SerializeField] float speed;
    Vector2 directionToMove;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        directionToMove = Vector2.zero;
    }
    public void FixedUpdate()
    {
        Move();
        directionToMove = Vector2.zero;
    }
    public void Move()
    {
        myBody.velocity = directionToMove * speed * Time.deltaTime;
    }
    public void SetDirection(Vector2 direction)
    {
        directionToMove += direction; directionToMove.Normalize();
    }
}
