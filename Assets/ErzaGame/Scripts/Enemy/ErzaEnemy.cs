using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ErzaEnemy : MonoBehaviour,ICanTakeDamage
{
    [Header("FX")]
    public GameObject hurtEffect;
    //[HideInInspector]
    [Header("MaxHealth")]
    public bool isDead = false;
    public float MaxHealth = 100f;
    public int damageToGive = 20;
    public Vector2 force;

    public float nextTime = 0f;
    public float rateTime = 0.5f;
    

    private float currentHealth = 0;
    private int isDeadId;
    private int isAttackId;

    private Animator anim;
    private ErzaPlayer player;

    // Start is called before the first frame update
    void Start()
    {
         currentHealth = MaxHealth;
        isDeadId = Animator.StringToHash("isDead");
        isAttackId = Animator.StringToHash("isAttack");
        anim = GetComponentInChildren<Animator>();
        
        player = GameObject.FindObjectOfType<ErzaPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void TakeDamage(int damage, Vector2 force, GameObject instigattor)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (hurtEffect != null)
        {
            Instantiate(hurtEffect, instigattor.transform.position, Quaternion.identity);
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            
            isDead = true;
            anim.SetTrigger(isDeadId);
            Destroy(gameObject, 3f);
        }
        Debug.Log("Eneme bi chem");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (player.isDead) return;

        if (player == null) return;

        if (collision.CompareTag("Player"))
        {
            if(Time.time > nextTime)
            {
                nextTime = Time.time + rateTime;
                anim.SetTrigger(isAttackId);
                player.TakeDamage(damageToGive, force, gameObject);
            }
        }
    }
}
