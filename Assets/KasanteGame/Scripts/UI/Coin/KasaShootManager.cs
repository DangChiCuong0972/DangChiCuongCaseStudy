using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KasaShootManager : MonoBehaviour
{
    public static KasaShootManager Instan;
    public int coin;
    public UnityEvent coinEvent;

    private void Awake()
    {
        if (coinEvent != null)
        {
            coinEvent = new UnityEvent();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Instan = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCoin(int coin)
    {
        this.coin += coin;
        coinEvent?.Invoke();

    }
    public int GetCoin()
    {
        return coin;
    }
}
