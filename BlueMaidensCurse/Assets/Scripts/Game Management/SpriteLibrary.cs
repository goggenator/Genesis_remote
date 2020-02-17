using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] public class SpriteLibrary : MonoBehaviour
{
    public static SpriteLibrary I; //Instance of this sprite library, so that it can be accessed from anywhere


    public void Update()
    {
        if(I == null)
        {
            I = this; //Sets the instance to be this object every time the editor is updated
        }
    }

    public Sprite[] treeSprites;
    public Sprite[] wallSprites;

    public Sprite GetSprite(TreeType type) //This gives back the correct sprite to the tree
    {
        switch (type) //The switch statement is better when checking an enum than an if statement would be
        {
            case TreeType.Tree1:
                return treeSprites[0];
            case TreeType.Tree2:
                return treeSprites[1];
            case TreeType.Tree3:
                return treeSprites[2];
            case TreeType.Tree4:
                return treeSprites[3];
            case TreeType.Tree5:
                return treeSprites[4];
            case TreeType.Tree6:
                return treeSprites[5];
            case TreeType.Tree7:
                return treeSprites[6];
            default:
                return treeSprites[0];
        }
    }
    public Sprite GetWallSprite(bool isLeft)
    {
        if(isLeft)
        {
            return wallSprites[0];
        }
        else
        {
            return wallSprites[1];
        }
    }
}
