using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    List<EnemyController> enemies = new List<EnemyController>();
    List<Item> spawnedItems = new List<Item>();
    [SerializeField] List<Item> items;
    [SerializeField] int EnemiesKilled = 0;
    int EnemiesKilledThisRound = 0;
    [SerializeField] HighScoreManager highScoreManager;

    public void Awake()
    {
        foreach (Transform child in transform)
        {
            if(child.GetComponent<EnemyController>())
            {
                enemies.Add(child.GetComponent<EnemyController>());
            }
        }
    }

    public void AddEnemyToList(EnemyController enemy)
    {
        enemies.Add(enemy);
    }
    public void Update()
    {
        UpdateEnemies();
        UpdateItems();
    }
    public void UpdateEnemies()
    {
        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                continue;
            }
            if (enemies[i].GetIsDead())
            {
                if (enemies[i].GetComponent<DropItem>())
                {
                    DropItem(enemies[i].GetComponent<DropItem>().GetItem(), enemies[i].GetComponent<DropItem>().GetLocation());
                }
                highScoreManager.AddScore(enemies[i].GetScore());
                enemies[i].OnDeath();
                enemies.Remove(enemies[i]); //change to a for loop instead, and remove the return;
                EnemiesKilled++; EnemiesKilledThisRound++;
                i++;
            }
        }
    }

    public void UpdateItems()
    {
        for (int i = 0; i < spawnedItems.Count; i++)
        {
            if (spawnedItems[i] == null)
            {
                continue;
            }
            if (spawnedItems[i].GetPickedUp())
            {
                if(GetComponent<ItemManager>().OnPickUp(spawnedItems[i].GetItem()))
                {
                    Destroy(spawnedItems[i].gameObject);
                    spawnedItems.Remove(spawnedItems[i]);
                    i++;
                }
            }
        }
    }

    public void DropItem(ItemType itemType, Transform trans)
    {
        foreach(Item item in items)
        {
            Debug.Log(EnemiesKilled);
            if(EnemiesKilled == 0)
            {
                Debug.Log("Looking for big meat");
                if(item.GetItem() == ItemType.bigMeat)
                {
                    spawnedItems.Add(Instantiate(item, trans.position, Quaternion.identity));
                }
            }
            else
            {
                if (item.GetItem() == itemType)
                {
                    spawnedItems.Add(Instantiate(item, trans.position, Quaternion.identity));
                }
            }
        }
    }
    public int GetAmountOFEnemiesKilled()
    {
        return EnemiesKilledThisRound;
    }
    public void ResetRound()
    {
        EnemiesKilledThisRound = 0;
    }
}
