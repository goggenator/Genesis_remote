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
        animator.SetFloat("Horizontal", movementManager.GetFacingDirection().x);
        animator.SetFloat("Vertical", movementManager.GetFacingDirection().y);
        animator.SetBool("Walking", movementManager.GetWalking());
    }
}
