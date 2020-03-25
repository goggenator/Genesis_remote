using UnityEngine;
using System.Collections;

public class AnimationListener : MonoBehaviour
{
    EntityController controller;

    private void Awake()
    {
        controller = GetComponentInParent<EntityController>();
    }
    public void OnDeath()
    {
        controller.SetIsDead();
    }
    public void SetSpawned()
    {
        controller.SetIsSpawned();
        controller.GetComponent<MovementManager>().SetFrozen(false);
    }
}
