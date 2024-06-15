using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("LightScript/LightGameManager")]
public class LightGameManager : MonoBehaviour
{
    
    public static LightGameManager Instance
    {
        get => instance;
    }
    private static LightGameManager instance;

    public UnityEvent<int> coinEvent;
    public UnityEvent<int> coinUpdateEvent;

    private int coin;

    private void Awake()
    {
        if(instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        if(coinEvent == null)
        {
            coinEvent = new UnityEvent<int>();
        }
        if(coinUpdateEvent == null)
        {
            coinUpdateEvent = new UnityEvent<int>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        coin = LightDataManager.DataCoin;
        coinEvent.AddListener(AddCoin);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin(int coin)
    {
        this.coin += coin;
        LightDataManager.DataCoin = this.coin;
        coinUpdateEvent?.Invoke(this.coin);
    }

   
}
