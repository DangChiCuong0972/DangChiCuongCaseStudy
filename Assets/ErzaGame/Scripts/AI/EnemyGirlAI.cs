using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;



[AddComponentMenu("ErzaScript/EnemyGirlAI")]
public class EnemyGirlAI : MonoBehaviour
{
    
    public Transform pointA;
    public Transform pointB;
    public float speedMove = 1f;
    public float speedPartrol = 1f;
    public float speedChasing = 2f;
    public float MinDistance = 0.2f;
    public float idleTime;
    public float baseIdleTime = 2f;
    public float chaseRange = 4f;

    private bool isWalk = false;
    private bool isChasing = false;
    private ErzaEnemy erzaEnemy;

    private Transform target;
    private Animator anim;
    private Rigidbody2D rb;
    
    private int isIdleAnimtionId = Animator.StringToHash("isIdle");

    //private float distancePlayer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        transform.position = pointA.position;
        target = pointB;
        idleTime = baseIdleTime;
        player = GameObject.FindGameObjectWithTag("Player");
        erzaEnemy = GetComponent<ErzaEnemy>();

    }

    // Update is called once per frame
    void Update()
    {
        if (erzaEnemy.isDead)
        {
            
            return;
        } 

        Movement();
    } 

    void Movement()
    {
        //if (player == null)
        //{
        //    Vector2 a = new Vector2(-40, 0);
        //    distancePlayer = Vector2.Distance(transform.position, a);
        //}
        //else
        //{
        //    distancePlayer = Vector2.Distance(transform.position, player.transform.position);
        //}
   
        float distancePlayer = Vector2.Distance(transform.position, player.transform.position);

        if (player != null && distancePlayer < chaseRange)
        {
            isChasing = true;
        }
        else 
        {
            isChasing = false;
        }
        if (isChasing)
        {
            Chasing();
        }
        else
        {
            Partrol();

        }
        Vector2 scale = transform.localScale;

        float x = player.transform.position.x - transform.position.x;
        if (x < 0 && isChasing)
        {
            scale.x = -(math.abs(scale.x));
        }
        else if (x > 0 & isChasing)
        {
            scale.x = (math.abs(scale.x));
        }

        if ((transform.position.x - pointA.position.x < 0) && (transform.position.x - pointB.position.x < 0) && !isChasing)
        {
            scale.x = (math.abs(scale.x));
        }
        else if ((transform.position.x - pointA.position.x > 0) && (transform.position.x - pointB.position.x) > 0 && !isChasing)
        {
            scale.x = -(math.abs(scale.x));
        }
        transform.localScale = scale;
        IdleAnimation();
    }

    public void Chasing()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * speedChasing;
        anim.SetBool(isIdleAnimtionId, false);
        Vector2 scale = transform.localScale;
        float x = player.transform.position.x - transform.position.x;
          
        
        transform.localScale = scale;
    }

    private void Partrol()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("isIdle"))
        {
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;

        if (Vector2.Distance(transform.position, target.position) < MinDistance)
        {
            target = target == pointB ? pointA : pointB;
            anim.SetBool(isIdleAnimtionId, true);

            Vector2 scale = transform.localScale;
            scale.x *= -1;

            transform.localScale = scale;
            speedMove = 0;   

            isWalk = false;    
        }

        
        rb.velocity = direction * speedMove;
    }
    void IdleAnimation()
    {
        if (!isWalk)
        {
            idleTime -= Time.deltaTime;
            if (idleTime <= 0)
            {
                anim.SetBool(isIdleAnimtionId, false);           
                idleTime = baseIdleTime;
                speedMove = speedPartrol;   
                isWalk = true;
            }
        }
    }

   
}
