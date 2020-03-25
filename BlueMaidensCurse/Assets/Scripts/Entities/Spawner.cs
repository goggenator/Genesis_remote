using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnerDirection
{
    north = 0,
    south = 1,
    left = 2,
    right = 3
}
public class Spawner : MonoBehaviour
{
    [SerializeField] int amountToSpawn = 0;
    [SerializeField] EnemyController enemyToSpawn = null;
    [SerializeField] Transform entityParent = null;
    [SerializeField] SpawnerDirection direction;
    public void Spawn(EntityManager entityManager)
    {
        for(int i = 0; i < amountToSpawn; i++)
        {
            EnemyController newEnemy = Instantiate(enemyToSpawn, transform.position, Quaternion.identity, entityParent);
            Vector2 directionToGive = Vector2.zero;
            switch(direction)
            {
                case SpawnerDirection.north:  
                    directionToGive = new Vector2(0,1);
                    break;
                case SpawnerDirection.south:
                    directionToGive = new Vector2(0, -1);
                    break;
                case SpawnerDirection.left:
                    directionToGive = new Vector2(-1, 0);
                    break;
                case SpawnerDirection.right:
                    directionToGive = new Vector2(1, 0);
                    break;
            }
            newEnemy.SetSpawnDirection(directionToGive);
            if(newEnemy is DraugController)
            {
                newEnemy.GetComponent<MovementManager>().SetFrozen(true);
            }
            entityManager.AddEnemyToList(newEnemy);
        }
    }
    public int GetSpawnAmount()
    {
        return amountToSpawn;
    }
}
