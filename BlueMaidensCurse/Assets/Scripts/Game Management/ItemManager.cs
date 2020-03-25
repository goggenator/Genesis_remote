﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Curse curse;
    [SerializeField] HealthManager HP;
    [SerializeField] uint amountOfMeatEaten = 0;
    bool potionPickedUp = false;
    bool firstMeatPickedUp = false;

    public bool OnPickUp(ItemType type)
    {
        switch (type)
        {
            case ItemType.meat:
                if (HP.GetHP() < 9)
                {
                    FindObjectOfType<AudioManager>().Play("Eat_Small");
                    curse.IncreaseCurse();
                    HP.OnHeal(3);
                }
                else
                {
                    return false;
                }
                amountOfMeatEaten++;
                PlaySound();

                return true;
            case ItemType.potion:
                FindObjectOfType<AudioManager>().Play("Potion");
                curse.ResetCurse();
                potionPickedUp = true;


                return true;
            case ItemType.bigMeat:
                if (amountOfMeatEaten == 0)
                {
                    curse.ActivateCurse();
                }
                FindObjectOfType<AudioManager>().Play("Eat_Big");
                HP.OnRestoreHP();
                curse.IncreaseCurse();
                amountOfMeatEaten++;
                PlaySound();

                if (amountOfMeatEaten == 1 && firstMeatPickedUp == false)
                {
                    FindObjectOfType<AudioManager>().Play("CurseStarts");
                    FindObjectOfType<AudioManager>().Play("PlayerEatFirstMeat");
                    firstMeatPickedUp = true;
                }
                return true;
            default: return false;
        }
    }
    public void PlaySound()
    {
        if (amountOfMeatEaten % 5 == 0)
        {
            string[] WhisperArray = new string[3] { "Whisper1", "Whisper2", "Whisper3" };
            FindObjectOfType<AudioManager>().Play(WhisperArray[Random.Range(0, 4)]); 
        }
        else
        {
            return;
        }
    }

    public void Whisper(uint amountOfMeatEaten)
    {

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
