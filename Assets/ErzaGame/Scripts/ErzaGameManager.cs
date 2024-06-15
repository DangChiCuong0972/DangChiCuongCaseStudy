using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[AddComponentMenu("ErzaScript/ErzaGameManager")]
public class ErzaGameManager : MonoBehaviour
{
    public static ErzaGameManager Instance
    {
        get => instance;
    }
    private static ErzaGameManager instance;

    private int power;
    //

    public UnityEvent<int> powerEvent;
    public UnityEvent<int>  powerUpdateEvent;

    private void Awake()
    {
        if(instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        if(powerEvent == null)
        {
            powerEvent = new UnityEvent<int>();
        }
        if(powerUpdateEvent == null)
        {
            powerEvent = new UnityEvent<int>();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        power = ErzaDataManager.DataPower;
        powerEvent.AddListener(AddPower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPower(int power)
    {
        this.power += power;
        ErzaDataManager.DataPower = this.power;
        powerUpdateEvent?.Invoke(this.power);
    }
    public int GetPower()
    {
        return power;
    }
}
