using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour //This is the script that should be used for everything that moves!
{
    Rigidbody2D myBody;
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector2 movementDirection)
    {
        Debug.Log(movementDirection);
        myBody.velocity = movementDirection;
    }
}
