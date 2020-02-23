using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSegment : MonoBehaviour
{
    public void UpdateEdge(bool isLeft)
    {
        GetComponentInChildren<SpriteRenderer>().sprite = SpriteLibrary.I.GetWallSprite(isLeft);
    }
}
