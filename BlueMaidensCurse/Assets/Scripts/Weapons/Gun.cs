using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    Shoot shoot;
    [SerializeField] Projectile projectile;
    [SerializeField] float shootingSpeed;
    public void Awake()
    {
        shoot = GetComponent<Shoot>();
    }
    override public void OnAttack(Vector2 direction, Vector2 origin, string identity)
    {
        shoot.OnShoot(shootingSpeed, projectile, direction, origin, identity);
    }
}
