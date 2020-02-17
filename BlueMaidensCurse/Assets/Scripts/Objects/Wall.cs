using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Wall : MonoBehaviour
{
    [SerializeField]int amountOfWalls;
    [SerializeField]WallSegment wall;
    [SerializeField] List<WallSegment> walls;
    Transform[] children;

    public void Update()
    {
        children = GetComponentsInChildren<Transform>();
        if(walls.Count != amountOfWalls)
        {
            DestroyWalls();
            for (int i = 0; i < amountOfWalls; i++)
            {
                Debug.Log("Instantiating");
                Debug.Log(i);
                walls.Add(Instantiate(wall, transform));
                walls[i].transform.position = new Vector2(transform.position.x + i * 2, transform.position.y);
            }
            walls[0].UpdateEdge(true);
            walls[amountOfWalls - 1].UpdateEdge(false);
        }
    }
    public void DestroyWalls()
    {
        Debug.Log("Deleting walls");
        for(int i = children.Length;i >= 0; i--)
        {
            Debug.Log(i);
            DestroyImmediate(children[i]);
            i++;
        }
        walls.Clear();
    }
}
