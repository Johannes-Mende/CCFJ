using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharackterConroller : MonoBehaviour
{
    public float MovementSpeed = 2f;

    private bool dashButtonDown;
    private bool facingRight = true;
    private Rigidbody2D rb;
    Vector2 movement;

    public float attackRate = 1f;
    float nextAttackTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            dashButtonDown = true;
        }

        if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (movement.x < 0 && facingRight)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MovementSpeed * Time.fixedDeltaTime);
        if (Time.time >= nextAttackTime)
        {
            if (dashButtonDown)
            {
                float dashAmount = 100f;
                rb.MovePosition(rb.position + movement * Time.fixedDeltaTime * dashAmount);
                dashButtonDown = false;
                nextAttackTime = Time.time + 1f / attackRate;
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
