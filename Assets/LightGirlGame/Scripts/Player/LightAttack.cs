using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("LightScript/LightAttack")]
public class LightAttack : MonoBehaviour
{
    public LayerMask enemyLayer;
    public Transform pointAttack;
    public float radiusAttack = 0.4f;

    public float nextAttack = 0;
    public float rateAttack = 2f;
    public float timeDelayAttack = 0.4f;

    public int damgeToGive = 50;
    public Vector2 force;

    private Animator anim;
    private int attackAnimationId;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        attackAnimationId = Animator.StringToHash("isAttack");

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GetKeyR();
           
        }
    }

    private bool GetKeyR()
    {
        if (Time.time > nextAttack)
        {
            anim.SetTrigger(attackAnimationId);
            nextAttack = Time.time + rateAttack;
            StartCoroutine(Attack(timeDelayAttack));

            return true;
        }
        else return false;
    }

    IEnumerator Attack(float delay)
    {
        yield return new WaitForSeconds(delay);

        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(pointAttack.position, radiusAttack, enemyLayer);

        foreach(var enemy in hitEnemys)
        {
            enemy.GetComponent<LightCanTakeDamage>().TakeDamage(damgeToGive, force, gameObject);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (pointAttack != null)
        {
            Gizmos.DrawWireSphere(pointAttack.position, radiusAttack);
        }
    }
}
