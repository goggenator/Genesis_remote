using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    meat = 0,
    potion = 1,
    bigMeat = 2,
    none = 3
}

public class Item : MonoBehaviour
{
    bool pickedUp = false;
    [SerializeField] ItemType myType;
    public ItemType GetItem()
    {
        return myType;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<HealthManager>())
            {
                return;
            }
            pickedUp = true;
        }
    }
    public bool GetPickedUp()
    {
        return pickedUp;
    }
}
