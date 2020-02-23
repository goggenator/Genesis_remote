using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShadow : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.collider.gameObject);
        Destroy(transform.parent.gameObject);
    }
}
