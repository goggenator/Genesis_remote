using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MovementManager movement;

    public void Awake()
    {
        movement = GetComponent<MovementManager>();
    }
    public void Move(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.W: movement.SetDirection(new Vector2(0, 1));
                break;
            case KeyCode.A: movement.SetDirection(new Vector2(-1, 0));
                break;
            case KeyCode.S: movement.SetDirection(new Vector2(0, -1));
                break;
            case KeyCode.D: movement.SetDirection(new Vector2(1, 0));
                break;
            default:
                break;
        }
    }
}
