using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] ItemType itemToDrop;

    public ItemType GetItem()
    {
        return itemToDrop;
    }
    public Transform GetLocation()
    {
        return transform;
    }
}
