using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MovementSpeed = 2f;

    public bool dashButtonDown;
    private bool facingRight = true;
    private Rigidbody2D rb;

    public float dashRate = 1f;
    float nextDashTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (GameManager.access.IK.movementX > 0 && !facingRight)
        {
            Flip();
        }
        else if (GameManager.access.IK.movementX < 0 && facingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        Vector2 V2 = new Vector2(GameManager.access.IK.movementX, GameManager.access.IK.movementY);
        rb.MovePosition(rb.position + V2 * MovementSpeed * Time.fixedDeltaTime);

        if (Time.time >= nextDashTime)
        {
            if (dashButtonDown)
            {
                float dashAmount = 100f;
                rb.MovePosition(rb.position + V2 * Time.fixedDeltaTime * dashAmount);
                dashButtonDown = false;
                nextDashTime = Time.time + dashRate;
            }
        }    

    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
