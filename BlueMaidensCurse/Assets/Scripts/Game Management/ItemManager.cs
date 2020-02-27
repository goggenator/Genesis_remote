using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Curse curse;
    [SerializeField] HealthManager HP;
    [SerializeField] uint amountOfMeatEaten = 0;
    public void OnPickUp(ItemType type)
    {
        switch(type)
        {
            case ItemType.meat:
                if(amountOfMeatEaten == 0)
                {
                    HP.OnRestoreHP();
                    curse.ResetCurse();
                }
                else
                {
                    curse.IncreaseCurse();
                    HP.OnHeal(3);
                }
                amountOfMeatEaten++;
                break;
            case ItemType.potion: curse.ResetCurse();
                break;
            default: break;
        }
    }

    public uint GetAmountOfMeatEaten()
    {
        return amountOfMeatEaten;
    }
}
