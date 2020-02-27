using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Curse curse;
    [SerializeField] HealthManager HP;
    [SerializeField] uint amountOfMeatEaten = 0;
    public bool OnPickUp(ItemType type)
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
                    if(HP.GetHP() < 9)
                    {
                        curse.IncreaseCurse();
                        HP.OnHeal(3);
                    }
                    else
                    {
                        return false;
                    }
                }
                amountOfMeatEaten++;
                return true;
            case ItemType.potion: curse.ResetCurse();
                return true;
            default: return false;
        }
    }

    public uint GetAmountOfMeatEaten()
    {
        return amountOfMeatEaten;
    }
}
