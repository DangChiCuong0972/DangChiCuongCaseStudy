using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEngine;

[AddComponentMenu("LightScript/EnemyWhiteGirlAI")]
public class EnemyWhiteGirlAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speedPartrol = 1;
    public float speedMove = 1f;
    public float speedChasing = 2f;
    public float chaiseRange = 4f;
    public float idleTime = 0;
    public float baseIdleTime = 3f;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private GameObject player;

    private bool isWalk;
    private bool isChasing;

    private int isIdleId;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");
        isIdleId = Animator.StringToHash("isIdle");
        idleTime = baseIdleTime;
        transform.position = pointA.position;
        target = pointB;
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
        IdleAAnimation();
    }

    void Movement()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < chaiseRange)
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

        float x = player.transform.position.x - transform.position.x;
        Vector2 scale = transform.localScale;

        if (x < 0 && isChasing)
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
    }

    void Chasing()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * speedChasing;
    }

    private void Partrol()
    {
        Vector2 scale = transform.localScale;

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            anim.SetBool(isIdleId, true);
            target = (target == pointA) ? pointB : pointA;

            scale.x *= -1;

            isWalk = false;
            speedPartrol = 0;
            transform.localScale = scale;
        }

        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speedPartrol;
    }

    void IdleAAnimation()
    {
        if(!isWalk)
        {
            idleTime -= Time.deltaTime;
            if(idleTime <= 0)
            {
                anim.SetBool(isIdleId, false);
                idleTime = baseIdleTime;
                isWalk = true;
                speedPartrol = speedMove;
            }
        }
    }
}
