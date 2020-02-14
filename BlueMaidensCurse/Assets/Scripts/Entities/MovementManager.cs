using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour //This is the script that should be used for everything that moves!
{
    Rigidbody2D myBody;
    [SerializeField] float speed;
    Vector2 directionToMove;
    Vector2 facingDirection;

    [SerializeField] bool canAttack;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        directionToMove = Vector2.zero; facingDirection = new Vector2(0, -1);
    }
    public void FixedUpdate()
    {
        Move();
        directionToMove = Vector2.zero;
    }
    public void Move()
    {
        myBody.velocity = directionToMove * speed * Time.deltaTime;
    }
    public void SetDirection(Vector2 direction)
    {
        directionToMove += direction;
        directionToMove.Normalize();
        facingDirection = directionToMove;
        facingDirection = new Vector2(Mathf.Round(facingDirection.x), Mathf.Round(facingDirection.y));
    }
    public Vector2 GetDirection()
    {
        return directionToMove.normalized;
    }
    public Vector2 GetFacingDirection()
    {
        return facingDirection;
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    public void SetCantAttack()
    {
        canAttack = false;
    }
    public bool CanAttack()
    {
        return canAttack;
    }
    public void OnDeath()
    {
        Destroy(gameObject);
    }
    public IEnumerator WaitUntilCanAttack(float reloadTime)
    {
        canAttack = false;
        yield return new WaitForSeconds(reloadTime);
        canAttack = true;
    }
}
