using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasaEnemyRedBoss : MonoBehaviour
{
    public float nextAttack = 0f;
    public float rateAttack = 3f;
    public GameObject redBullet01;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextAttack)
        {
            nextAttack = Time.time + rateAttack;
            SetBullet();
        }

        if(KasaShootManager.Instan.GetCoin() >= 50)
        {
            rateAttack = 1f;
        }
    }

    private void SetBullet()
    {
        if(redBullet01 != null)
        {
            Instantiate(redBullet01, transform.position, Quaternion.identity);

        }
    }
}
