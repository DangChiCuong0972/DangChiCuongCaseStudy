using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("LightScript/LightDataManager")]
public static class LightDataManager 
{
    public static int DataCoin
    {
        get => PlayerPrefs.GetInt(LightConstanKey.coinKeyId, 0);
        set => PlayerPrefs.SetInt(LightConstanKey.coinKeyId, value);
    }

    public static float DataMusic
    {
        get => PlayerPrefs.GetFloat(LightConstanKey.KeymusicId, 1);

        set => PlayerPrefs.SetFloat(LightConstanKey.KeymusicId, value);
    }

    public static float DataSfx
    {
        get => PlayerPrefs.GetFloat(LightConstanKey.KeySfxId, 1);
        set => PlayerPrefs.SetFloat(LightConstanKey.KeySfxId, value);
    }
}
