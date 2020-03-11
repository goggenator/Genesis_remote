using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    MovementManager movement;
    [SerializeField]int damage;
    [SerializeField] Vector2 movementDirection;
    ProjectileShadow shadow;
    string identity; //is the player or enemy casting this

    public void Awake()
    {
        shadow = GetComponentInChildren<ProjectileShadow>();
        StartCoroutine(WaitUntilDespawn());
        movement = GetComponent<MovementManager>();
    }
    public void Update()
    {
        movement.SetDirection(movementDirection);
    }
    public void SetSpeed(float speed)
    {
        movement.SetSpeed(speed);
    }
    public void SetDirection(Vector2 direction)
    {
        movementDirection = direction;
    }
    public void SetIdentity(string casterIdentity)
    {
        identity = casterIdentity;
    }
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<HealthManager>())
        {
            if (!collision.gameObject.CompareTag(identity)) //if the tag on the object this projectile collided with is not the same as the tag of the caster
            {
                if (collision.gameObject.GetComponentInParent<EntityController>())
                {
                    collision.gameObject.GetComponentInParent<EntityController>().OnHit(damage);
                    Destroy(gameObject);
                }
            }
        }
    }
    public IEnumerator WaitUntilDespawn()
    {
        yield return new WaitForSeconds(2);
        movement.OnDeath();
    }
}
