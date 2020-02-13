using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(isEntity)
        {
            layer = 2 * (int)(transform.position.y * 10);
        }
        else
        {
            layer = (2 * (int)(transform.position.y * 10)) + 1;
        }
        m_renderer.sortingOrder = -layer;
    }
}
