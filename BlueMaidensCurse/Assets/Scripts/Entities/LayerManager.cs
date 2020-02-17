using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LayerManager : MonoBehaviour
{
    [SerializeField] int layer;
    SpriteRenderer m_renderer;
    public bool isEntity;
    public void Awake()
    {
        m_renderer = GetComponentInChildren<SpriteRenderer>();
    }
    public void Update()
    {
        m_renderer.transform.position = transform.position;
        int lowerLeftPosition = 2 * (int)((transform.position.y - m_renderer.sprite.bounds.extents.y) * 10);
        if (isEntity)
        {
            layer = lowerLeftPosition;
        }
        else
        {
           // Debug.Log("Object: " + gameObject + ", Y: " +(transform.position.y - m_renderer.sprite.bounds.extents.y) * 10);
            layer = lowerLeftPosition + 1;
        }
        m_renderer.sortingOrder = -layer;
    }
}
