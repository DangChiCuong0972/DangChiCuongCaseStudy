using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("MyScript/GameManager")]
public class GameManager : MonoBehaviour
{
    private int coin ;
    public static GameManager Instance
    {
        get => instance;
    }

    private static GameManager instance;

    public UnityEvent<int> coinEvent;
    public UnityEvent<int> coinEventUpdate;
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

        if(coinEventUpdate == null)
        {
            coinEventUpdate = new UnityEvent<int>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        coin = DataManager.DataCoin;
        coinEvent.AddListener(AddCoin);
        // Event Game Manager 
        //if(EventGameManager.coinEvent == null)                  
        //{
        //    EventGameManager.coinEvent = new GameEvent();
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin(int coin)
    {
        this.coin += coin;
        DataManager.DataCoin = this.coin;
        coinEventUpdate?.Invoke(this.coin);
        //EventGameManager.coinEvent?.Invoke(this.coin);
    }

   
}
