using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game I;

    [SerializeField] PauseMenu pauseMenu;

    [SerializeField] GameObject DeathScreen;

    [SerializeField] GameObject Player;

    [SerializeField] SpawnerManager spawnerManager;

    [SerializeField] ItemManager itemManager;

    bool timeToSpawnBoss = false;
    bool spawningPaused = false;

    int round = 1;

    private void Awake()
    {
        I = this;
    }

    public void Update()
    {
        if(Player != null)
        {
            if(itemManager.GetIsPotionPickedUp())
            {
                spawningPaused = false;
            }
            if(spawnerManager != null && itemManager.GetAmountOfMeatEaten() > 0 && !timeToSpawnBoss && !spawningPaused)
            {
                if (!spawnerManager.GetSpawning())
                {
                    StartCoroutine(spawnerManager.Spawn(spawnerManager.ChooseSpawners(), spawnerManager.ChooseWaveAmount()));
                }
                if(spawnerManager.GetAmountOfEnemiesKilledThisRound() > 25 * round)
                {
                    spawningPaused = true;
                    timeToSpawnBoss = true;
                }
            }
            else if(timeToSpawnBoss)
            {
                spawnerManager.SpawnBoss();
                timeToSpawnBoss = false;
            }
            if (Player.GetComponentInChildren<HealthManager>().GetHP() <= 0)
            {
                Player.GetComponent<MovementManager>().OnDeath();
                DeathScreen.SetActive(true);
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
    public void OnLockPositionKeyPress()
    {
        if(Player != null)
        {
            Player.GetComponent<PlayerController>().LockPosition();
        }
    }
    public void OnLockPositionKeyLift()
    {
        if (Player != null)
        {
            Player.GetComponent<PlayerController>().UnlockPosition();
        }
    }
}
