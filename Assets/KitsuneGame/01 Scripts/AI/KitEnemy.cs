using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("KitScript/KitEnemy")]
public class KitEnemy : MonoBehaviour,KitCanTakeDamage
{
    public GameObject hurtEffect;
    public int maxHealth = 100;
    public int currentHealth = 0;

    public bool isDead = false;

    private Animator anim;

    private int isDeadId;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        currentHealth = maxHealth;

        isDeadId = Animator.StringToHash("isDead");
    }

    // Update is called once per frame
  
    public void TakeDamage(int damge, Vector2 force, GameObject intergor)
    {
      if(isDead)
        {
            return;
        }

      if(hurtEffect != null)
        {
            Instantiate(hurtEffect, transform.position, Quaternion.identity);
        }
        currentHealth -= damge;
        if(currentHealth <= 0)
        {
            anim.SetTrigger(isDeadId);
            currentHealth = 0;
            isDead = true;
            Destroy(gameObject, 3f);
        }

        Debug.Log("Enemy bi chem");
    }
}
