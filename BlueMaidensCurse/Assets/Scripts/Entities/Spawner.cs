using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int amountToSpawn;
    [SerializeField] EnemyController enemyToSpawn;
    [SerializeField] Transform entityParent;
    public void Spawn(EntityManager entityManager)
    {
        for(int i = 0; i < amountToSpawn; i++)
        {
            entityManager.AddEnemyToList(Instantiate(enemyToSpawn, transform.position, Quaternion.identity, entityParent));
        }
    }
}
