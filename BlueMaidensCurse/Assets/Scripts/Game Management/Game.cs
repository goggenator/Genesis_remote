using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game I;

    [SerializeField] PauseMenu pauseMenu;

    [SerializeField] GameObject Player;

    [SerializeField] SpawnerManager spawnerManager;

    private void Awake()
    {
        I = this;
    }

    public void Update()
    {
        if(Player != null)
        {
            if(spawnerManager != null)
            {
                if (!spawnerManager.GetSpawning())
                {
                    StartCoroutine(spawnerManager.Spawn(spawnerManager.ChooseSpawners(), spawnerManager.ChooseWaveAmount()));
                }
                if (Player.GetComponentInChildren<HealthManager>().GetHP() <= 0)
                {
                    Player.GetComponent<MovementManager>().OnDeath();
                }
            }
        }
    }

    public void TogglePause()
    {
        pauseMenu.TogglePause();
    }
    public void OnMovementKeyPress(KeyCode key)
    {
        if(Player != null)
        {
            Player.GetComponent<PlayerController>().Move(key);
        }
    }
    public void OnActionKeyPress()
    {
        if(Player != null)
        {
            Player.GetComponent<PlayerController>().Attack();
        }
    }
    public Vector2 GetPlayerPosition()
    {
        if(Player != null)
        {
            return Player.transform.position;
        }
        else
        {
            return Vector2.zero;
        }
    }
}
