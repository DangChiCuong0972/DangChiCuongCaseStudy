using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("KitScript/KitGameManager")]
public class KitGameManager : MonoBehaviour
{
    public static KitGameManager Instance
    {
        get => instance;
    }
    private static KitGameManager instance;

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

        if(KitEventManager.coinEvent == null)
        {
            KitEventManager.coinEvent = new KitGameEvent();
        }

        if(KitEventManager.coinUpdateEvent == null)
        {
            KitEventManager.coinUpdateEvent = new KitGameEvent();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        coin = KitDataManager.DataCoin;

        KitEventManager.coinEvent.AddListener(AddCoin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin(int coin)
    {
        this.coin += coin;
        KitDataManager.DataCoin = this.coin;
        KitEventManager.coinUpdateEvent?.Invoke(this.coin);
    }

    public int GetCoin()
    {
        return coin;
    }
}
