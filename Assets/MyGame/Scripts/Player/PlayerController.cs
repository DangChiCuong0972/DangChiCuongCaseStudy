using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("MyScript/PlayerController")]
public class PlayerController : MonoBehaviour
{
    public LayerMask groundLayer;
    [SerializeField] Transform groundCheck;

    private Rigidbody2D rb;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpFore = 5f;

    private SpriteRenderer spriteCharacter;
    private bool isGround = false;
    private bool facingRight = true;

    private int isWalkAnimationid = Animator.StringToHash("isWalk");
    private int isJumid = Animator.StringToHash("isJum");
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteCharacter = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
          
            Jum();
        }
        //if (Input.GetKeyUp(KeyCode.Space))
        //{
        //    NotJum();
        //}
        if (rb.velocity.y == 0)
        {
            NotJum();
        }

    }



    private void NotJum()
    {
        anim.SetBool(isJumid, false);
    }

    private void Jum()
    {
            
            rb.velocity = new Vector2(rb.velocity.x, jumpFore);
            anim.SetBool(isJumid, true);
        
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);
        
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight )
        {
            Flip();
        }

        if(Mathf.Abs(horizontal)>0)
        {
            anim.SetBool(isWalkAnimationid, true);
        }
        else
        {
            anim.SetBool(isWalkAnimationid, false);
        }

      
    }

    private void Flip()
    {
        facingRight = !facingRight;
        //spriteCharacter.flipX = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
