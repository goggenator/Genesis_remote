using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    Shoot shoot;
    [SerializeField] Projectile projectile;
    [SerializeField] float shootingSpeed;
    [SerializeField] int amountOfShots;
    [SerializeField] float spreadAngle;
    public void Awake()
    {
        shoot = GetComponent<Shoot>();
    }
    override public void OnAttack(Vector2 direction, Vector2 origin, string identity)
    {
        float separatedAngle = spreadAngle / amountOfShots;
        separatedAngle -= (spreadAngle / 2);
        for(int i = 0; i < amountOfShots; i++)
        {
            Vector2 newDirection = new Vector2(direction.x * Mathf.Cos(separatedAngle*Mathf.Deg2Rad) - direction.y * Mathf.Sin(separatedAngle * Mathf.Deg2Rad), direction.x * Mathf.Sin(separatedAngle * Mathf.Deg2Rad) + direction.y * Mathf.Cos(separatedAngle * Mathf.Deg2Rad));
            shoot.OnShoot(shootingSpeed, projectile, newDirection, origin, identity);
            separatedAngle += spreadAngle / amountOfShots;
        }
    }
}
