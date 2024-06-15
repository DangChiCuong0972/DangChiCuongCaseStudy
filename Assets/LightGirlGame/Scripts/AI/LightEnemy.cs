using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("LightScript/LightEnemy")]
public class LightEnemy : MonoBehaviour,LightCanTakeDamage
{
    public GameObject hurtEffect;
    public int maxHealth = 100;

    public float nextAttack = 0;
    public float rateAttack = 3;

    public bool isDead = false;
    public int damageToGive = 20;
    public Vector2 force;

    private int currentHealth = 0;

    private LightPlayer lightPlayer;

    private Animator anim;

    private int isDeadId;
    private int isAttackId;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        anim = GetComponentInChildren<Animator>();

        lightPlayer = FindObjectOfType<LightPlayer>();

        isDeadId = Animator.StringToHash("isDead");
        isAttackId = Animator.StringToHash("isAttack");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage, Vector2 force, GameObject interger)
    {

        if (isDead) return;

        if(hurtEffect != null)
        {
            Instantiate(hurtEffect, transform.position, Quaternion.identity);
        }
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            anim.SetTrigger(isDeadId);
            currentHealth = 0;
            isDead = true;
            Destroy(gameObject, 3f);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(Time.time > nextAttack)
            {
                anim.SetTrigger(isAttackId);
                nextAttack = Time.time + rateAttack;
                lightPlayer.TakeDamage(damageToGive, force, gameObject);
            }
        }
    }
}
