using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("ErzaScript/ErzaPlayer")]
public class ErzaPlayer : MonoBehaviour,ICanTakeDamage
{
    public GameObject hurtEffect;
    public float maxHealth = 100f;
    public bool isDead = false;

    private float currentHealth = 0;

    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage, Vector2 force, GameObject instigattor)
    {
        if (isDead) return;

        currentHealth -= damage;

        if(hurtEffect != null )
        {
            Instantiate(hurtEffect, transform.position, Quaternion.identity);
        }

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;

           // gameObject.SetActive(false);
            Destroy(gameObject, 3f);        
           // Load Scene 
           // Load UI 

        }

        Debug.LogError("Player bi chem");
    }


    
}
