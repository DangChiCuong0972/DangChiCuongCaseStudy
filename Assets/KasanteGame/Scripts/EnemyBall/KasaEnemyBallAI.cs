using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KasaEnemyBallAI : MonoBehaviour
{
    public Transform pointBall01;
    public Transform pointBall02;
    public float speedMove = 2f;
    public int coinValue = 5;
    private Vector2 target;
    public GameObject hurtEffect;

    public AudioSource hurtScource;
    public AudioClip hurtSfx;
    private bool makeFX = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = pointBall01.position;
       
    }

    // Update is called once per frame
    void Update()
    {
       
        if (transform.position == pointBall01.position)
        {
            target = pointBall02.position;

        }
        else if (transform.position == pointBall02.position)
        {
            target = pointBall01.position;

        }
        transform.position =  Vector2.MoveTowards(transform.position, target, speedMove * Time.deltaTime);

      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("BulletFXQ3"))
        {
            KasaShootManager.Instan.SetCoin(coinValue);
            SetHurtAudio(hurtSfx);
            if(hurtEffect != null)
            {
                Instantiate(hurtEffect, transform.position, Quaternion.identity);
            }
        }
    }

    public void SetHurtAudio(AudioClip clip)
    {
        hurtScource.PlayOneShot(clip);
    }
}
