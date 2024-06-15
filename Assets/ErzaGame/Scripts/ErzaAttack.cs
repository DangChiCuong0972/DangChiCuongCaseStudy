using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("ErzaScript/ErzaAttack")]
public class ErzaAttack : MonoBehaviour
{
    public float radiusAttack = 0.2f;
    public Transform pointAttack;
    public float attackRate = 0.2f;
    public float nextAttack = 0f;
    public float timeDelay = 0.2f;

    public LayerMask enemyLayer;
    public int damageToGive = 50;
    public Vector2 force;

    private Animator anim;
    private int attackAnimationId = Animator.StringToHash("triggerAttack");
    private int attack02Id;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        attack02Id = Animator.StringToHash("isAttack02");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger(attackAnimationId);
            GetKeyR();
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger(attack02Id);
        }

       

    }

    private bool GetKeyR()
    {
        if(Time.time > nextAttack )
        {
            nextAttack = Time.time + attackRate;
            StartCoroutine(Attack(timeDelay));
            return true;
        }
        else
        {
            return false;
        }

    }

    IEnumerator Attack(float delay)
    {
        yield return new WaitForSeconds(delay);
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(pointAttack.position, radiusAttack,enemyLayer);

       
            foreach (var enemy in hitEnemys)
            {
            var canTake = enemy.GetComponent<ICanTakeDamage>();
            if (canTake != null)
                   {
                      canTake.TakeDamage(damageToGive, force, gameObject);
                   }
            }
        
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        if (pointAttack != null)
        {
            Gizmos.DrawWireSphere(pointAttack.position, radiusAttack);
        }
    }


}
