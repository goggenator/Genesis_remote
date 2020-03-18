using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] List<ItemType> dropRate;
    public ItemType GetItem()
    {
        return dropRate[Random.Range(0, dropRate.Count)];
    }
    public Transform GetLocation()
    {
        return transform;
    }
}
