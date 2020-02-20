using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] EntityManager entityManager;
    [SerializeField] List<Spawner> spawners;
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
        return new List<int> { 0 };
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
