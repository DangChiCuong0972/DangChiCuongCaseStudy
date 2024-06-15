using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("KitScript/KitAttack")]
public class KitAttack : MonoBehaviour
{
    public LayerMask enemyLayer;
    public Transform pointAttack;
    public float radiusAttack;

    public int damageToGive = 50;
    public Vector2 force;

    public float nextAttack = 0;
    public float rateAttack = 1f;
    public float timeDelayAttack = 0.4f;

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

    public bool GetKeyR()
    {
        if (Time.time > nextAttack)
        {
            anim.SetTrigger(attackAnimationId);
            nextAttack = Time.time + rateAttack;
            StartCoroutine(Attack(timeDelayAttack));
            return true;
        }
        else
            return false;
    }

    IEnumerator Attack(float delay)
    {
        yield return new WaitForSeconds(delay);

        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(pointAttack.position, radiusAttack, enemyLayer);

        foreach(var enemy in hitEnemys)
        {
            Debug.LogError("Enemy :" + enemy.name);
            enemy.GetComponent<KitCanTakeDamage>().TakeDamage(damageToGive, force, gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        if(pointAttack != null)
        {
            Gizmos.DrawWireSphere(pointAttack.position, radiusAttack);
        }
    }
}
