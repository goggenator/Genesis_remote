using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] int amountToSpawn;
    public void Awake()
    {
        amountToSpawn = 3;
    }
    public void Spawn()
    {

    }
}
