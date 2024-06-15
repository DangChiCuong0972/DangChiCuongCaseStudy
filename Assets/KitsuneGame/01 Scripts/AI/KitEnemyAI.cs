using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

[AddComponentMenu("KitScript/KitEnemyAI")]
public class KitEnemyAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float speedPartrol = 1f;
    public float speedMove = 1f;
    public float speedChasing = 1.5f;
    public float idleTime = 0;
    public float baseIdleTime = 3f;

    public float chaiSeRange = 4f;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject player;

    private bool isWalk = true;
    private bool isChasing;

    private int isIdleId;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        isIdleId = Animator.StringToHash("isIdle");

        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = pointA.position;

        target = pointB;

        idleTime = baseIdleTime;
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);
        if(distance < chaiSeRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

       
        if(isChasing)
        {
            Chasing();
        }
        else
        {
            Partrol();
        }
        Vector2 scale = transform.localScale;
        float x = player.transform.position.x - transform.position.x;
        if (x<0 && isChasing)
        {
            scale.x = -(math.abs(scale.x));
        }
        else if (x > 0 && isChasing)
        {
            scale.x = (math.abs(scale.x));
        }
        else if (transform.position.x - pointA.position.x < 0 && transform.position.x - pointB.position.x < 0 && !isChasing)
        {
            scale.x = (math.abs(scale.x));
        }
        else if (transform.position.x - pointA.position.x > 0 && transform.position.x - pointB.position.x > 0 && !isChasing)
        {
            scale.x = -(math.abs(scale.x));
        }
        transform.localScale = scale;

            IdleAnimation();
    }

    void Chasing()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * speedChasing;


    }
    private void Partrol()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        Vector2 scale = transform.localScale;


        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            anim.SetBool(isIdleId,true);
            target = target == pointB ? pointA : pointB;

            scale.x *= -1;
            transform.localScale = scale;

            isWalk = false;
            speedPartrol = 0;

        }
        rb.velocity = direction * speedPartrol;
    }

    void IdleAnimation()
    {
        if(!isWalk)
        {
            idleTime -= Time.deltaTime;
            if(idleTime <= 0)
            {
                anim.SetBool(isIdleId, false);
                speedPartrol = speedMove;
                idleTime = baseIdleTime;
                isWalk = true;
            }
        }
    }
}
