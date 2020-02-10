using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TreeType //We need this to send ths to the SpriteLibrary and get our sprite
{
    Tree1, Tree2, Tree3, Tree4, Tree5, Tree6, Tree7
}
[ExecuteAlways]
public class Environment_Tree: MonoBehaviour
{
    [SerializeField] //This makes a private variable editable from the inspector
    TreeType myType;
    [SerializeField] SpriteRenderer myRenderer;

    private void Update()
    {
        if(Application.IsPlaying(gameObject))
        {
            //Play logic
        }
        else
        {
            //Editor logic
            Debug.Log("Changing sprite");
            myRenderer.sprite = SpriteLibrary.I.GetSprite(myType);
        }
    }
}
