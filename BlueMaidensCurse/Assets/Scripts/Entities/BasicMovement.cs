using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    MovementManager movementManager;
    EntityController controller;

    void Awake()
    {
        movementManager = GetComponent<MovementManager>();
        controller = GetComponent<EntityController>();
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", movementManager.GetFacingDirection().x);
        animator.SetFloat("Vertical", movementManager.GetFacingDirection().y);
        animator.SetBool("Walking", movementManager.GetWalking());
        animator.SetFloat("SpawnX", controller.SpawnDirection.x);
        animator.SetFloat("SpawnY", controller.SpawnDirection.y);
        animator.SetBool("Spawned", controller.GetIsSpawned());
    }
}
