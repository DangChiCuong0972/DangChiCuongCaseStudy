using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("KitScript/KitController")]
public class KitController : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform groundCheck;

    [SerializeField] float speedMove = 1f;
    [SerializeField] float jumForce = 5f;

    private bool isGround = false;
    private bool facingRight = true;

    private int RunAnimationId;
    private int JumAnimationId;

    private Rigidbody2D rb;
    private SpriteRenderer spriteCharacter;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
        spriteCharacter = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();

        RunAnimationId = Animator.StringToHash("isRun");
        JumAnimationId = Animator.StringToHash("isJum");
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
            rb.velocity = new Vector2(rb.velocity.x, jumForce);
            anim.SetBool(JumAnimationId, true);
        }
        else if(rb.velocity.y == 0)
        {
            anim.SetBool(JumAnimationId, false);
        }

    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speedMove, rb.velocity.y);

        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            Flip();
        }

        if(Mathf.Abs(horizontal) > 0 )
        {
            anim.SetBool(RunAnimationId, true);
        }
        else
        {
            anim.SetBool(RunAnimationId, false);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        //spriteCharacter.flipX = !facingRight;
        Vector2 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
        
    }


}
