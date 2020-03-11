using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressspacetoskip: MonoBehaviour
{
    //Animator anim;

    //void Start()
    //{
    //    anim = gameObject.GetComponent<Animator>();
    //}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
