using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Curse curse;
    [SerializeField] HealthManager HP;
    public void OnPickUp(ItemType type)
    {
        switch(type)
        {
            case ItemType.meat:
                curse.IncreaseCurse();
                HP.OnHeal(3);
                break;
            case ItemType.potion: curse.ResetCurse();
                break;
            default: break;
        }
    }
}
