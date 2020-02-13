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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            g.TogglePause();
            //pause or resume PauseMenu
        }
        if(Input.GetKey(KeyCode.W))
        {
            g.OnMovementKeyPress(KeyCode.W);
        }
        if (Input.GetKey(KeyCode.A))
        {
            g.OnMovementKeyPress(KeyCode.A);
        }
        if (Input.GetKey(KeyCode.S))
        {
            g.OnMovementKeyPress(KeyCode.S);
        }
        if (Input.GetKey(KeyCode.D))
        {
            g.OnMovementKeyPress(KeyCode.D);
        }
    }
}
