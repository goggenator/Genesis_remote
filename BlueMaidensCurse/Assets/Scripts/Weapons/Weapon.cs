using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   [SerializeField] float reloadTime;
   virtual public void OnAttack(Vector2 direction, Vector2 origin, string identity)
   {
   }
    public float GetReloadTime()
    {
        return reloadTime;
    }
}
