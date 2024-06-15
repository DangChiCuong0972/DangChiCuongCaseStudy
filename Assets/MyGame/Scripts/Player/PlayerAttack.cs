using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyScript/PlayerAttack")]
public class PlayerAttack : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radiusAttack = 0.2f;
    public Transform pointAttack;

    public int damageToGive = 50;
    public Vector2 force;

    public float nextAttack = 0f;
    public float rateAttack = 0.5f;
    public float timeDamageDelay = 0.2f;

    private Animator anim;
    private int isAttackAnimationId;

    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        isAttackAnimationId = Animator.StringToHash("isAttack");


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GetKeyR();
           // Attack01();

        }    
    }
    #region test01
    private bool GetKeyR()
    {
        if (Time.time > nextAttack)
        {
            anim.SetTrigger(isAttackAnimationId);
            nextAttack = Time.time + rateAttack;
           // Attack01();
            StartCoroutine(Attack(timeDamageDelay));

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

        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(pointAttack.position, radiusAttack, enemyLayer);


        //foreach (var enemy in hitEnemys)
        //{
        //    var canTake = enemy.GetComponent<MyCanTakeDamage>();
        //    if (canTake != null)
        //    {
        //        canTake.TakeDamage(damageToGive, force, gameObject);
        //    }
        //}

        foreach (Collider2D enemy in hitEnemys)
        {

            enemy.GetComponent<MyEnemy>().TakeDamage(damageToGive, force, gameObject);     

        }

    }
    #endregion
    //public void Attack01()
    //{
    //    anim.SetTrigger(isAttackAnimationId);
    //    Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(pointAttack.position, radiusAttack, enemyLayer);
    //    foreach (Collider2D enemy in hitEnemys)
    //    {
    //        enemy.GetComponent<MyEnemy>().TakeDamage(damageToGive);

    //    }
    //}


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (pointAttack != null)
        {
            Gizmos.DrawWireSphere(pointAttack.position, radiusAttack);
        }
    }

    //public void TakeDamage(int damage, Vector2 force, GameObject instigattor)
    //{

    //}
}
