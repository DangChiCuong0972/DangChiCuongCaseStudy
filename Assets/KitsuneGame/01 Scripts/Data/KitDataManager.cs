using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("KitScript/KitDataManager")]
public static class KitDataManager 
{
    public static int DataCoin
    {
        get => PlayerPrefs.GetInt(KitConstanKey.CoinKeyId, 0);
        set => PlayerPrefs.SetInt(KitConstanKey.CoinKeyId, value);
    }
}
