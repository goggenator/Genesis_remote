using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralShooting : MonoBehaviour
{
    [SerializeField] Projectile projectile = null;
    [SerializeField] Shoot shoot = null;
    [SerializeField] float shootingSpeed;
    [SerializeField] float shootingDelay;
    [SerializeField] float cooldown;
    [SerializeField] int amountOfSpins;
    [SerializeField] int amountOfProjectiles;

    bool isShooting = false;
    bool shootingInitiated = false;

    void StartShooting()
    {
        StartCoroutine(Shoot());
    }
    public void Update()
    {
        if(isShooting && !shootingInitiated)
        {
            StartCoroutine(Shoot());
            shootingInitiated = true;
        }
    }
    public bool GetIsShooting()
    {
        return isShooting;
    }
    public void SetIsShooting(bool value)
    {
        isShooting = value;
    }
    public IEnumerator Shoot()
    {
        for(int i = 0; i < amountOfSpins; i++)
        {
            float angle = 360 / amountOfProjectiles;
            Vector2 direction = new Vector2(0, 1);
            for (int j = 0; j < amountOfProjectiles; j++)
            {
                yield return new WaitForSeconds(shootingDelay);
                shoot.OnShoot(shootingSpeed, projectile, direction, transform.position, "Enemy");
                direction = new Vector2(direction.x * Mathf.Cos(angle * Mathf.Deg2Rad) - direction.y * Mathf.Sin(angle * Mathf.Deg2Rad), direction.x * Mathf.Sin(angle * Mathf.Deg2Rad) + direction.y * Mathf.Cos(angle * Mathf.Deg2Rad));
            }
        }
        yield return new WaitForSeconds(shootingDelay);
        shoot.OnShoot(shootingSpeed, projectile, new Vector2(0, 1), transform.position, "Enemy");
        yield return new WaitForSecondsRealtime(cooldown);
        isShooting = false;
        shootingInitiated = false;
    }
}
