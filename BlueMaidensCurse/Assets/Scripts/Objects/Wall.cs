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
                walls.Add(Instantiate(wall, transform));
                if(i != 0)
                {
                    walls[i].transform.position = new Vector2(transform.position.x + i * walls[i - 1].GetComponentInChildren<SpriteRenderer>().size.x, transform.position.y);
                }
                else
                {
                    walls[0].transform.position = new Vector2(transform.position.x, transform.position.y);
                }
            }
            if(walls[0] != null)
            {
                if(walls[1]!= null)
                {
                    walls[0].UpdateEdge(true);
                    walls[amountOfWalls - 1].UpdateEdge(false);
                }
            }
        }
        children.Clear();
    }
    public void DestroyWalls()
    {
        for (int i = children.Count - 1; i >= 0; i--)
        {
            DestroyImmediate(children[i].gameObject);
        }
        walls.Clear();
    }
}
