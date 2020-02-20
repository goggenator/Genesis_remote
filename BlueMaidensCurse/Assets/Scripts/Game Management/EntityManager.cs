using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    List<EnemyController> enemies = new List<EnemyController>();
    List<Item> spawnedItems = new List<Item>();
    [SerializeField] List<Item> items;

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
        foreach (EnemyController enemy in enemies)
        {
            if (enemy == null)
            {
                continue;
            }
            if (enemy.GetIsDead())
            {
                if (enemy.GetComponent<DropItem>())
                {
                    DropItem(enemy.GetComponent<DropItem>().GetItem(), enemy.GetComponent<DropItem>().GetLocation());
                }
                enemy.OnDeath();
                enemies.Remove(enemy); //change to a for loop instead, and remove the return;
                return;
            }
        }
    }

    public void UpdateItems()
    {
        foreach (Item spawnedItem in spawnedItems)
        {
            if (spawnedItem == null)
            {
                continue;
            }
            if (spawnedItem.GetPickedUp())
            {
                GetComponent<ItemManager>().OnPickUp(spawnedItem.GetItem());
                spawnedItems.Remove(spawnedItem);
                Destroy(spawnedItem.gameObject);
                spawnedItems.Remove(spawnedItem);
                return;
            }
        }
    }

    public void DropItem(ItemType itemType, Transform trans)
    {
        foreach(Item item in items)
        {
            if(item.GetItem() == itemType)
            {
                spawnedItems.Add(Instantiate(item, trans.position, Quaternion.identity));
            }
        }
    }
}
