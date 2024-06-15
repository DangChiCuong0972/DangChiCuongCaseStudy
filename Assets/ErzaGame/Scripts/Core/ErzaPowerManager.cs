using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("ErzaScript/ErzaPowerManager")]
public class ErzaPowerManager : MonoBehaviour
{
    public int powerValue = 1;
    public AudioClip powerSfx;
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
            ErzaGameManager.Instance.powerEvent?.Invoke(powerValue);
            ErzaAudioManager.Instance.PlaySfx(powerSfx);
            Destroy(gameObject);
        }
    }
}
