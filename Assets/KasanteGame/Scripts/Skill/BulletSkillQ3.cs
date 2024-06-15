using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSkillQ3 : MonoBehaviour
{
    public float speed = 3f;
    public float timeDelayBullet = 4f;

    private KasaController kasaController;
    private Rigidbody2D rb;
    
   // public Vector3 hurtFxQ3;
    // Start is called before the first frame update
    void Start()
    {
        kasaController = FindObjectOfType<KasaController>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, timeDelayBullet);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
       
           // transform.Translate(speed * Time.deltaTime, 0, 0);
      
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
           // other.gameObject.transform.position +=  hurtFxQ3;
            Destroy(gameObject);
        }
    }
}
