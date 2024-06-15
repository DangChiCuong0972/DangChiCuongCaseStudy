using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataManager 
{
    public static int DataCoin
    {
        get => PlayerPrefs.GetInt(ConstanKey.KeyCoinid, 0);
        set => PlayerPrefs.SetInt(ConstanKey.KeyCoinid, value);
    }

    public static float DataMusic
    {
        get => PlayerPrefs.GetFloat(ConstanKey.KeyMusic, 1);
        set => PlayerPrefs.SetFloat(ConstanKey.KeyMusic, value);
    }

    public static float DataSfx
    {
        get => PlayerPrefs.GetFloat(ConstanKey.KeySfx, 1);
        set => PlayerPrefs.SetFloat(ConstanKey.KeySfx, value);
    }
}
