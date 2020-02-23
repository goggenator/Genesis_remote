using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogManager : MonoBehaviour
{
    List<GameObject> fogClouds = new List<GameObject> { };
    [SerializeField] GameObject fog;

    Vector2 getRandomOffset()
    {
        return new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.4f, 0.4f));
    }
    float getRandomSpeed()
    {
        return Random.Range(5f, 35f);
    }
    Vector2 getRandomDirection()
    {
        int[] temp = { -1, 1 };
        return new Vector2(temp[Random.Range(0, 2)], 0);
    }
    private void Awake()
    {
        for(int i = 0 ; i < 80; i++)
        {
            for(int j = 0; j < 20; j++)
            {
                GameObject cloud = Instantiate(fog, new Vector2(j * 2 - 20, (float)i / 2 - 20) + getRandomOffset(), Quaternion.identity, transform);
                fogClouds.Add(cloud);
                cloud.GetComponent<MovementManager>().SetConstantDirection(getRandomDirection());
                cloud.GetComponent<MovementManager>().SetSpeed(getRandomSpeed());
            }
        }
    }
    public void Update()
    {
        int cloudIndex = 0;
        for (int i = 0; i < 80; i++)
        {
            for (int j = 0; j < 20; j++)
            {
                if (fogClouds[cloudIndex].transform.position.x < -20)
                {
                    fogClouds[cloudIndex].transform.position = new Vector2(20, (float)i / 2 - 20) + getRandomOffset();
                    fogClouds[cloudIndex].GetComponent<MovementManager>().SetConstantDirection(getRandomDirection());
                    fogClouds[cloudIndex].GetComponent<MovementManager>().SetSpeed(getRandomSpeed());
                }
                if (fogClouds[cloudIndex].transform.position.x > 20)
                {
                    fogClouds[cloudIndex].transform.position = new Vector2(-20, (float)i / 2 - 20) + getRandomOffset();
                    fogClouds[cloudIndex].GetComponent<MovementManager>().SetConstantDirection(getRandomDirection());
                    fogClouds[cloudIndex].GetComponent<MovementManager>().SetSpeed(getRandomSpeed());
                }
                cloudIndex++;
            }
        }
        if(Input.GetKey(KeyCode.K))
        {
            ToggleDissipation();
        }
    }
    public void ToggleDissipation()
    {
        foreach(GameObject cloud in fogClouds)
        {
            cloud.GetComponent<SpriteRenderer>().color = new Color
                (cloud.GetComponent<SpriteRenderer>().color.r,
                cloud.GetComponent<SpriteRenderer>().color.g,
                cloud.GetComponent<SpriteRenderer>().color.b,
                0)
                ;
        }
    }
}
