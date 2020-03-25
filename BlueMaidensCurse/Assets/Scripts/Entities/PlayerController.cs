using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : EntityController
{
    [SerializeField] Weapon equippedWeapon;

    public void Awake()
    {
        movement = GetComponent<MovementManager>();
        HP = GetComponentInChildren<HealthManager>();
        HP.InitializeHealth(HP.GetMaxHP()*0.20f);
        FindObjectOfType<AudioManager>().Play("Spawn_Boss");
    }
    public void Move(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.W: movement.SetDirection(new Vector2(0, 1));
                break;
            case KeyCode.A: movement.SetDirection(new Vector2(-1, 0));
                break;
            case KeyCode.S: movement.SetDirection(new Vector2(0, -1));
                break;
            case KeyCode.D: movement.SetDirection(new Vector2(1, 0));
                break;
            default:
                break;
        }
    }
    public void Attack()
    {
        if(movement.CanAttack())
        {
            equippedWeapon.OnAttack(movement.GetFacingDirection(), transform.position, "Player");
            if(equippedWeapon.GetReloadTime() * HP.GetHPPercentage() <= 0.2f)
            {
                StartCoroutine(movement.WaitUntilCanAttack(0.2f));
            }
            else
            {
                StartCoroutine(movement.WaitUntilCanAttack(equippedWeapon.GetReloadTime() * HP.GetHPPercentage()));
            }
        }
    }
    public void LockPosition()
    {
        movement.FreezeMovement();
        movement.SetCanMove(false);
    }
    public void UnlockPosition()
    {
        movement.SetCanMove(true);
    }
}
