using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyScript/MyCoinManager")]
public class MyCoinManager : MonoBehaviour
{
    public int addCoin = 1;

    public AudioClip coinSfx;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //GameManager.Instance.AddCoin(addCoin);
            MyAudioManager.Instance.SetSfxSource(coinSfx);
            GameManager.Instance.coinEvent?.Invoke(addCoin);
            Destroy(gameObject);
        }
    }
}
