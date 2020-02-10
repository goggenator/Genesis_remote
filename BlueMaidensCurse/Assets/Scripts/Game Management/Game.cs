using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game I;

    [SerializeField] Vector2 playerPosition; //This saves where the player is at all times, so anything can get the position

    private void Awake()
    {
        I = this;
    }

    public Vector2 GetPlayerPosition()
    {
        return playerPosition;
    }
    public void SetPlayerPosition(Vector2 position)
    {
        playerPosition = position;
    }
}
