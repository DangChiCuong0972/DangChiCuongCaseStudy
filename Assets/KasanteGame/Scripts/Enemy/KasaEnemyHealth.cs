using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasaEnemyHealth : MonoBehaviour,KasaCanTakeDamage
{
    public GameObject hurtEffectQ1;
    public int maxHealth = 100;
    public bool isDead = false;
    private int currentHealth = 0;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage, GameObject intergor)
    {
        if (isDead) return;

        currentHealth -= damage;

        if(hurtEffectQ1 != null)
        {
            Instantiate(hurtEffectQ1,transform.position + new Vector3(0,0,-3), Quaternion.identity);
        }

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            Destroy(gameObject, 2f);
        }
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
