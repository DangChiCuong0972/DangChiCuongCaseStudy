using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("LightScript/LightCoinManager")]
public class LightCoinManager : MonoBehaviour
{
    public AudioClip coinSfx;
    public int addCoin = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LightAudioManager.Instance.SetSfxSource(coinSfx);
            LightGameManager.Instance.coinEvent?.Invoke(addCoin);
            Destroy(gameObject);
        }
    }
}
