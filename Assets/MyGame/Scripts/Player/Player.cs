using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[AddComponentMenu("MyScript/Player")]
public class Player : MonoBehaviour,ICanTakeDamage
{
    public GameObject hurtEffect;
    public int maxHealth = 100;
   
    
    public Vector2 force;

    public bool isDead = false;

   
    private int currentHealth = 0;

    private Animator anim;

    private int isDeadId;



    private void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponentInChildren<Animator>();

        isDeadId = Animator.StringToHash("isDead");
    }

    

    public void TakeDamage(int damage, Vector2 force, GameObject instigattor)
    {
        if (isDead)
        {
            return;
        }

        if (hurtEffect != null)
        {
            Instantiate(hurtEffect, transform.position, Quaternion.identity);
        }

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            anim.SetTrigger(isDeadId);
            currentHealth = 0;
            isDead = true;
            Destroy(gameObject, 3f);
        }

        Debug.LogError("Player bi chem");
    }



}
