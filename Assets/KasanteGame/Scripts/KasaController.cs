using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasaController : MonoBehaviour
{

    public float speedMove = 2f;
    private Rigidbody2D rb;

    private bool facingRight = true;

    public CinemachineVirtualCamera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            cam.m_Lens.OrthographicSize = 13f;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            cam.m_Lens.OrthographicSize = 8f;
        }
       
    }


    private void Movement()
    {
         float horizontal = Input.GetAxis("Horizontal");
          float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontal * speedMove, vertical * speedMove);


        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        //Vector2 scale = transform.localScale;
        //scale.x *= -1;
        //transform.localScale = scale;
        transform.Rotate(0f, 180f, 0f);
    }

    
}
