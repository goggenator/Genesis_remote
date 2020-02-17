using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSegment : MonoBehaviour
{
    public void UpdateEdge(bool isLeft)
    {
        SpriteLibrary.I.GetWallSprite(isLeft);
    }
}
