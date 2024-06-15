using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasaRedBulletBoxss : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2f;
    public float timeDelay = 3f;
    public int recudeCoin = -10;
    public GameObject hurtEffect;
    private Vector3 move = new Vector3(-1, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeDelay);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = move * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.CompareTag("Player"))
        {
            KasaShootManager.Instan.SetCoin(recudeCoin);
            HurtEffectPlayer();
        }
    }

    public void HurtEffectPlayer()
    {
        if(hurtEffect != null)
        {
            Instantiate(hurtEffect, transform.position, Quaternion.identity);
        }
    }
}
