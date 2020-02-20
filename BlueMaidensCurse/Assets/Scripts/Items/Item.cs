using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    meat = 0,
    potion = 1
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
        Debug.Log("Colliding with: " + collision);
        if(collision.gameObject.CompareTag("Player"))
        {
            pickedUp = true;
        }
    }
    public bool GetPickedUp()
    {
        return pickedUp;
    }
}
