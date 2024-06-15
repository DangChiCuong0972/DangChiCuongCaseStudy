using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[AddComponentMenu("LightScript/LightController")]
public class LightController : MonoBehaviour
{
    public LayerMask groundLayer;
    public Transform groundCheck;

    [SerializeField] float speedMove = 3f;
    [SerializeField] float jumFore = 4f;
    private Rigidbody2D rb;
    private SpriteRenderer spriteCharacter;
    private Animator anim;

    private bool isGround ;
    private bool facingRight = true;

    private int RunAnimationId = Animator.StringToHash("isRun");
    private int JumAnimationId;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteCharacter = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
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
            rb.velocity = new Vector2(rb.velocity.x, jumFore);

            anim.SetBool(JumAnimationId, true);
        }
        else if (rb.velocity.y == 0)
        {
            anim.SetBool(JumAnimationId, false);
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(horizontal * speedMove, rb.velocity.y);

        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            Flip();
        }

        if (Mathf.Abs(horizontal) > 0)
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
        // spriteCharacter.flipX = !facingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
