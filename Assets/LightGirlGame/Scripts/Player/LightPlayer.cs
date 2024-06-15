using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("LightScript/LightPlayer")]
public class LightPlayer : MonoBehaviour,LightCanTakeDamage
{
    public GameObject hurtEffect;

   

    public int maxHealth = 100;

    private int currentHealth = 0;

    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
     

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
            currentHealth = 0;
            isDead = true;
            Destroy(gameObject,3f);
        }

        Debug.Log("Player bi chem");
        
    }
}
