using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public void OnShoot(float speed, Projectile projectile, Vector2 direction, Vector2 origin, string identity)
    {
        Projectile newProjectile = Instantiate(projectile);
        newProjectile.SetSpeed(speed);
        newProjectile.SetDirection(direction);
        newProjectile.SetIdentity(identity);
        newProjectile.transform.position = origin;
        if(transform.parent.transform.parent.GetComponent<Entity>())
        {
            Physics2D.IgnoreCollision(transform.parent.transform.parent.GetComponent<Entity>().positionCollider, newProjectile.GetComponentInChildren<ProjectileShadow>().GetComponent<BoxCollider2D>());
        }
        else
        {
            Physics2D.IgnoreCollision(transform.parent.GetComponent<Entity>().positionCollider, newProjectile.GetComponentInChildren<ProjectileShadow>().GetComponent<BoxCollider2D>());
        }
    }
}
