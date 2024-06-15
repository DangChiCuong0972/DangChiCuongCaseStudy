using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemy : MonoBehaviour,ICanTakeDamage
{
    public GameObject hurtEffect;
    public int maxHealth = 100;

    public float nextAttck = 0f;
    public float rateAttack = 1f;

    public int damageToGive = 50;
    public Vector2 force;

    public bool isDead = false;


    private int currentHealth = 0;

    private int isDeadId;
    private int isAttackId;

    private Animator anim;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindObjectOfType<Player>();

        currentHealth = maxHealth;
        isDeadId = Animator.StringToHash("isDead");
        isAttackId = Animator.StringToHash("isAttack");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage, Vector2 force, GameObject instigattor)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= damage;

        if (hurtEffect != null)
        {
            Instantiate(hurtEffect, gameObject.transform.position, Quaternion.identity);
        }
        if (currentHealth <= 0)
        {
            anim.SetTrigger(isDeadId);
            currentHealth = 0;
            isDead = true;
            Destroy(gameObject, 2f);
        }

        Debug.LogWarning("Enemy bi chem");
    }

    //public void TakeDamage(int damage,Vector2 force,GameObject interger)
    //{
    //    if (isDead)
    //    {
    //        return;
    //    }

    //    currentHealth -= damage;

    //    if (hurtEffect != null)
    //    {
    //        Instantiate(hurtEffect, gameObject.transform.position, Quaternion.identity);
    //    }
    //    if (currentHealth <= 0)
    //    {
    //        anim.SetTrigger(isDeadId);
    //        currentHealth = 0;
    //        isDead = true;
    //        Destroy(gameObject, 2f);
    //    }

    //    Debug.LogWarning("Enemy bi chem");
    //}


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (player.isDead) return;

        if (player == null) return;

        if (collision.CompareTag("Player"))
        {
            if (Time.time > nextAttck)
            {
                anim.SetTrigger(isAttackId);
                nextAttck = Time.time + rateAttack;
                player.TakeDamage(damageToGive, force, gameObject);
            }
        }
    }
}
