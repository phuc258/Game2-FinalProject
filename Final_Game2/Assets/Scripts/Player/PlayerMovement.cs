using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private PlayerRespawn playerRespawn;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerAnimation playerAnimation;

    private void Awake()
    {
    }

    private void Update()
    {
        //Movement
        float horizontal = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && isGrounded())
        {
           Jump();
        }

        //Flip character
        if (horizontal < 0)
            spriteRenderer.flipX = true;
        else if (horizontal > 0)
            spriteRenderer.flipX = false;

        //Animation
        playerAnimation.RunAnimation(horizontal != 0);
        playerAnimation.GroundedAnimation(isGrounded());
    }

    private void Jump()
    {
            body.velocity = new Vector2(body.velocity.x, speed);
            playerAnimation.JumpAnimation();
    }
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private void onTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            playerRespawn.RespawnPlayer();
        }
    }
}
