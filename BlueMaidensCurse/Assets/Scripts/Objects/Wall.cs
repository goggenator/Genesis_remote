using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Wall : MonoBehaviour
{
    [SerializeField]int amountOfWalls;
    [SerializeField]WallSegment wall;
    [SerializeField] List<WallSegment> walls;
    [SerializeField] List<Transform> children;

    public void Update()
    {
        foreach(Transform child in transform)
        {
            children.Add(child);
        }
        if(walls.Count != amountOfWalls)
        {
            DestroyWalls();
            for (int i = 0; i < amountOfWalls; i++)
            {
                Debug.Log("Instantiating");
                Debug.Log(i);
                walls.Add(Instantiate(wall, transform));
                walls[i].transform.position = new Vector2(transform.position.x + i * 1.5f, transform.position.y);
            }
            if(walls[0] != null)
            {
                walls[0].UpdateEdge(true);
                walls[amountOfWalls - 1].UpdateEdge(false);
            }
        }
        children.Clear();
    }
    public void DestroyWalls()
    {
        Debug.Log("Deleting walls");
        Debug.Log("Amount of children: " + children.Count);
        foreach(Transform child in children)
        {
            Debug.Log(child);
        }
        for (int i = children.Count - 1; i >= 0; i--)
        {
            Debug.Log(i);
            DestroyImmediate(children[i].gameObject);
        }
        walls.Clear();
    }
}
