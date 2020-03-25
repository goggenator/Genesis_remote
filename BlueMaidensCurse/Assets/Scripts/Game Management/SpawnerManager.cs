using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] EntityManager entityManager;
    [SerializeField] List<Spawner> spawners;
    [SerializeField] Spawner bossSpawner;
    [SerializeField] float spawnRate;
    [SerializeField] bool spawning = false;
    int AmountOfEnemiesSpawnedThisRound = 0;

    public IEnumerator Spawn(List<int> activeSpawners, int amountOfWaves)
    {
        spawning = true;
        int i = 0;
        while (i != amountOfWaves)
        {
            yield return new WaitForSeconds(spawnRate);
            foreach(int j in activeSpawners)
            {
                if(j <= spawners.Count && spawners[j] != null)
                {
                    AmountOfEnemiesSpawnedThisRound += spawners[j].GetSpawnAmount();
                    spawners[j].Spawn(entityManager);
                }
            }
            i++;
        }
        spawning = false;
    }

    public List<int> ChooseSpawners()
    {
        List<int> newList = new List<int> { };
        int amountOfSpawners = Random.Range(0, 4);
        for(int i = 0; i < amountOfSpawners; i++)
        {
            int spawnerID = Random.Range(0, spawners.Count);
            if(!newList.Contains(spawnerID))
            {
                newList.Add(spawnerID);
            }
            else
            {
                i--;
            }
        }
        return newList;
    }

    public void SpawnBoss()
    {
        Debug.Log("Spawning Boss!!");
        FindObjectOfType<AudioManager>().Play("Spawn_Boss");
        bossSpawner.Spawn(entityManager);
    }

    public int ChooseWaveAmount()
    {
        return 3;
    }

    public bool GetSpawning()
    {
        return spawning;
    }

    public int GetAmountOfEnemiesSpawnedThisRound()
    {
        return AmountOfEnemiesSpawnedThisRound;
    }
    public int GetAmountOfEnemiesKilledThisRound()
    {
        return entityManager.GetAmountOFEnemiesKilled();
    }
    public void ResetRound()
    {
        AmountOfEnemiesSpawnedThisRound = 0;
        entityManager.ResetRound();
    }
}
