using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curse : MonoBehaviour
{
    float curseDamage = 0.01f;
    HealthManager HP;

    public void Awake()
    {
        HP = GetComponent<HealthManager>();
    }

    public void Update()
    {
        HP.OnHit(curseDamage * Time.deltaTime);
    }
}
