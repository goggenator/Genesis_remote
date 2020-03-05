using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public ItemType GetItem()
    {
        List<ItemType> itemsToChooseBetween = new List<ItemType>()
        {
            ItemType.meat, ItemType.meat, ItemType.meat,
            ItemType.bigMeat,
            ItemType.none,ItemType.none,ItemType.none,ItemType.none,ItemType.none,ItemType.none
        };

        return itemsToChooseBetween[Random.Range(0, itemsToChooseBetween.Count)];
    }
    public Transform GetLocation()
    {
        return transform;
    }
}
