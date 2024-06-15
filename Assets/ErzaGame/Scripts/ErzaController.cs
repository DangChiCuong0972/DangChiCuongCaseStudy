using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
[AddComponentMenu("ErzaScript/ErzaController")]
public class ErzaController : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    [SerializeField] float speedMove = 10f;
    [SerializeField] float jumpForce = 4f;

    private SpriteRenderer spriteCharacter;
    private Animator anim;

    private bool isGround = false;
    private bool facingRight = true;

    private int isWalkAnimationId = Animator.StringToHash("isWalk");
    private int isJumAnimationId = Animator.StringToHash("isJum");
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
        Jum();

        
    }

    private void Jum()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (isGround && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool(isJumAnimationId,true);
        }
        else if (rb.velocity.y == 0)
        {
            anim.SetBool(isJumAnimationId, false);
        }


    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(speedMove * horizontal, rb.velocity.y);

        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            Flip();
        }

        if(Mathf.Abs(horizontal ) > 0 )
        {
            anim.SetBool(isWalkAnimationId, true);
        }
        else
        {
            anim.SetBool(isWalkAnimationId, false);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        // spriteCharacter.flipX = !facingRight;

        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }


}
