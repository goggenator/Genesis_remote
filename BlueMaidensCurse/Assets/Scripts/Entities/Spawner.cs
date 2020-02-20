using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int amountToSpawn;
    [SerializeField] EnemyController enemyToSpawn;
    [SerializeField] Transform entityParent;
    public void Awake()
    {
        amountToSpawn = 3;
    }
    public void Spawn(EntityManager entityManager)
    {
        entityManager.AddEnemyToList(Instantiate(enemyToSpawn, transform.position, Quaternion.identity, entityParent));
    }
}
