using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking_script : MonoBehaviour
{
    [SerializeField] public Animator walking;
    public Animator up;
    public Animator down;
    public Animator right;
    public Animator left;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movment;
   
    public void Update()
    {
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("up-on");
            up.SetFloat("up", 1);
            down.SetFloat("down", 0);
            left.SetFloat("left", 0);
            right.SetFloat("right", 0);

        }
        
        if (Input.GetKeyUp(KeyCode.W))
        {
            Debug.Log("up-off");
            up.SetFloat("up", 0);

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("down-on");
            down.SetFloat("down", 1);
            up.SetFloat("up", 0);
            left.SetFloat("left", 0);
            right.SetFloat("right", 0);

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Debug.Log("down-off");
            down.SetFloat("down", 0);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("right-on");
            right.SetFloat("right", 1); 
            up.SetFloat("up", 0);
            down.SetFloat("down", 0);
            left.SetFloat("left", 0);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("right-off");
            right.SetFloat("right", 0);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("left-on");
            left.SetFloat("left", 1);
            up.SetFloat("up", 0);
            down.SetFloat("down", 0);
            right.SetFloat("right", 0);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("left-off");
            left.SetFloat("left", 0);

        }



    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movment * moveSpeed * Time.fixedUnscaledDeltaTime);
    }
}
