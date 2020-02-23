using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    private Game g;

    private void Awake()
    {
        g = GetComponent<Game>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            g.TogglePause();
            //pause or resume PauseMenu
        }
        if (Input.GetKey(KeyCode.Space))
        {
            g.OnActionKeyPress();
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            g.OnLockPositionKeyPress();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            g.OnLockPositionKeyLift();
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
            {
                g.OnMovementKeyPress(KeyCode.W);
            }
            if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                g.OnMovementKeyPress(KeyCode.S);
            }
            if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                g.OnMovementKeyPress(KeyCode.A);
            }
            if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
            {
                g.OnMovementKeyPress(KeyCode.D);
            }
        }
        else
        {
            //things you can only do while standing still
        }
    }
}
