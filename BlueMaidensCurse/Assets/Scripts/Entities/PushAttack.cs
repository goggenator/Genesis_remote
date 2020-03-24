using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAttack : MonoBehaviour
{
    MovementManager movement;
    [SerializeField] float pushStrength;
    public void Awake()
    {
        movement = GetComponentInParent<MovementManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponentInParent<MovementManager>())
            {
                collision.gameObject.GetComponentInParent<MovementManager>().Push(movement.GetFacingDirection(), pushStrength);
                collision.gameObject.transform.parent.GetComponentInChildren<HealthManager>().OnHit(2);
                FindObjectOfType<AudioManager>().Play("Push_Hit");
            }
        }
    }
}
