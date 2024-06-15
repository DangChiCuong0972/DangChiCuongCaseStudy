using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("ErzaScript/ErzaDataManager")]
public static class ErzaDataManager 
{
    public static int DataPower
    {
        get => PlayerPrefs.GetInt(ErzaConstanKey.powerId, 0);
        set => PlayerPrefs.SetInt(ErzaConstanKey.powerId, value);
    }

    public static float DataMusic
    {
        get => PlayerPrefs.GetFloat(ErzaConstanKey.KeyMusic, 1);
        set => PlayerPrefs.SetFloat(ErzaConstanKey.KeyMusic, value);
    }

    public static float DataSfx
    {
        get => PlayerPrefs.GetFloat(ErzaConstanKey.KeySfx, 1);
        set => PlayerPrefs.SetFloat(ErzaConstanKey.KeySfx, value);
    }
}
