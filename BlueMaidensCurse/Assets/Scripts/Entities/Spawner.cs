using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int amountToSpawn = 0;
    [SerializeField] EnemyController enemyToSpawn = null;
    [SerializeField] Transform entityParent = null;
    public void Spawn(EntityManager entityManager)
    {
        for(int i = 0; i < amountToSpawn; i++)
        {
            entityManager.AddEnemyToList(Instantiate(enemyToSpawn, transform.position, Quaternion.identity, entityParent));
        }
    }
    public int GetSpawnAmount()
    {
        return amountToSpawn;
    }
}
