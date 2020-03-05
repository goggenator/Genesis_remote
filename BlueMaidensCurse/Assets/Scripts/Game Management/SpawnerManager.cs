using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] EntityManager entityManager;
    [SerializeField] List<Spawner> spawners;
    [SerializeField] List<Spawner> gastSpawners;
    [SerializeField] Spawner bossSpawners;
    [SerializeField] float spawnRate;
    [SerializeField] bool spawning = false;

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

    public int ChooseWaveAmount()
    {
        return 3;
    }

    public bool GetSpawning()
    {
        return spawning;
    }
}
