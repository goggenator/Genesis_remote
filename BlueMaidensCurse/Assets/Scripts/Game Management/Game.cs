using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game I;

    [SerializeField] PauseMenu pauseMenu;

    [SerializeField] GameObject Player;

    private void Awake()
    {
        I = this;
    }

    public void TogglePause()
    {
        pauseMenu.TogglePause();
    }
    public void OnMovementKeyPress(KeyCode key)
    {
        Player.GetComponent<PlayerController>().Move(key);
    }
    public void OnActionKeyPress()
    {
        Player.GetComponent<PlayerController>().Attack();
    }
    public Vector2 GetPlayerPosition()
    {
        return Player.transform.position;
    }
}
