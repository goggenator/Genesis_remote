using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    MovementManager movementManager;

    void Awake()
    {
        movementManager = GetComponent<MovementManager>();
    }
    // Update is called once per frame
    void Update()
    {

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetBool("Walking", movementManager.GetWalking());

    }
}
