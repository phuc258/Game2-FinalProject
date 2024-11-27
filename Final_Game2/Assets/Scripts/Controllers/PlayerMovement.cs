using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //Movement
        float horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && isGrounded())
        {
           Jump();
        }

        //Flip character
        if (horizontal > 0.01f)
            transform.localScale = new Vector3(4, 4, 1);
        else if (horizontal < -0.01f)
            transform.localScale = new Vector3(-4, 4, 1);

        //Animation
        anim.SetBool("Run", horizontal != 0);
        anim.SetBool("Grounded", isGrounded());
    }

    private void Jump()
    {
            body.velocity = new Vector2(body.velocity.x, speed);
            anim.SetTrigger("Jump");
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
