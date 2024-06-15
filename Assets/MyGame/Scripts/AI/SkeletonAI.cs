using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
[AddComponentMenu("MyScript/SkeletonAI")]
public class SkeletonAI : MonoBehaviour
{
    public float speedPartrol = 1;
    public float speedMove = 1;
    public float speedChasing = 1.5f;
    public float chaseRange = 4f;

    public Transform pointA;
    public Transform pointB;
    public float minDistance = 0.1f;

    public float idleTime = 0f;
    public float baseIdleTime = 3f;

    private bool isWalk = true;
    private bool isChaSing = false;

    private int isIdleId;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private MyEnemy myEnemy;

    private GameObject player;
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        myEnemy = GetComponent<MyEnemy>();
        isIdleId = Animator.StringToHash("isIdle");

        player = GameObject.FindGameObjectWithTag("Player");

        idleTime = baseIdleTime;

        transform.position = pointA.position;
        target = pointB;


    }

    // Update is called once per frame
    void Update()
    {
        if (myEnemy.isDead  )
        {
            return;
        }
        
        Movement();
        
       
    }

    void Movement()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        Vector2 scale = transform.localScale;

        float x = player.transform.position.x - transform.position.x; 
        if (distance < chaseRange)
        {
            isChaSing = true;
        }
        else
        {
            isChaSing = false;
        }

        if (x < 0 && isChaSing)
        {
            scale.x = -(math.abs(scale.x));
        }
        else if (x > 0 && isChaSing)
        {
            scale.x = (math.abs(scale.x));
        }
        else if (transform.position.x - pointA.transform.position.x < 0 && transform.position.x - pointB.transform.position.x < 0 && !isChaSing)
        {
            scale.x = (math.abs(scale.x));
        }
        else if (transform.position.x - pointA.transform.position.x > 0 && transform.position.x - pointB.transform.position.x > 0 && !isChaSing)
        {
            scale.x = -(math.abs(scale.x));
        }

        transform.localScale = scale;

        if (isChaSing)
        {
            Chasing();
        }
        else
        {
            Partrol();
        }
        IdleAnimation();
    }

    void Chasing()
    {
        
        Vector2 direction = (player.transform.position - transform.position).normalized;

        rb.velocity = direction * speedChasing;
    }

    void Partrol()
    {


        Vector2 direction = (target.position - transform.position).normalized;
        if (Vector2.Distance(transform.position,target.position) < 0.1f)
        {
            anim.SetBool(isIdleId, true);          

            Vector2 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            speedPartrol = 0;
            isWalk = false;
            target = (target == pointA) ? pointB : pointA;           
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
                idleTime = baseIdleTime;
                speedPartrol = speedMove;
                isWalk = true;

            }
        }
             
    }
}
