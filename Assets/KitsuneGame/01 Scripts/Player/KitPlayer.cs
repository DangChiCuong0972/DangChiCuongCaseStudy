using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("KitScript/KitPlayer")]
public class KitPlayer : MonoBehaviour
{
    public int addCoin = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coin"))
        {
            KitEventManager.coinEvent?.Invoke(addCoin);
            Destroy(collision.gameObject);
        }
    }

}
