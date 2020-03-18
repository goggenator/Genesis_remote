using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Curse curse;
    [SerializeField] HealthManager HP;
    [SerializeField] uint amountOfMeatEaten = 0;
    bool potionPickedUp = false;
    public bool OnPickUp(ItemType type)
    {
        switch(type)
        {
            case ItemType.meat:
                if(HP.GetHP() < 9)
                {
                    curse.IncreaseCurse();
                    HP.OnHeal(3);

                }
                else
                {
                    return false;
                }
                amountOfMeatEaten++;
                return true;
            case ItemType.potion: 
                curse.ResetCurse();
                potionPickedUp = true;

                return true;
            case ItemType.bigMeat:
                if(amountOfMeatEaten == 0)
                {
                    curse.ActivateCurse();
                }
                HP.OnRestoreHP();

                curse.IncreaseCurse();
                amountOfMeatEaten++;
                return true;
            default: return false;
        }
    }

    public uint GetAmountOfMeatEaten()
    {
        return amountOfMeatEaten;
    }

    public bool GetIsPotionPickedUp()
    {
        return potionPickedUp;
    }
    public void ResetRound()
    {
        potionPickedUp = false;
    }
}
