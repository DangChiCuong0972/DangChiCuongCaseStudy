using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasaEnemy : MonoBehaviour
{
    public float speedFXQ3 = 1f;
    public float baseSpeedFxQ3 = 1f;
    public float moveFxRange = 2f;
    public bool  canCheckRange = false;

    private GameObject player;
    private Rigidbody2D rb;
    private bool isFXQ3 = false;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveFXQ3();
    }

    void moveFXQ3()
    {
        
        Vector2 direction = (player.transform.position - transform.position);

        float distance = Vector2.Distance(transform.position, player.transform.position);

      
        if (isFXQ3)
        {
            canCheckRange = true;
            rb.velocity = direction * speedFXQ3;
        }

        if (distance < moveFxRange && canCheckRange)
        {
            speedFXQ3 = 0;
            rb.velocity = direction * speedFXQ3;
            isFXQ3 = false;
        } 
        if(speedFXQ3 == 0)
        {
            canCheckRange = false;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BulletFXQ3"))
        {
            isFXQ3 = true;
            speedFXQ3 = baseSpeedFxQ3;
        }
    }
}
