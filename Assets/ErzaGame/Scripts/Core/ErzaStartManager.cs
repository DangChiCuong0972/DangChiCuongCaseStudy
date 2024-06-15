using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.UI;

[AddComponentMenu("ErzaScript/ErzaStartManager")]
public class ErzaStartManager : MonoBehaviour
{

    public Slider sliderMusic;
    public Slider sliderSfx;

    public GameObject panelMain;
    public GameObject panelOption;


    // Start is called before the first frame update
    void Start()
    {
        GetDataVolume();
        panelMain.SetActive(true);
        panelOption.SetActive(false);
    }

    void GetDataVolume()
    {
        sliderMusic.value = ErzaDataManager.DataMusic;
        sliderSfx.value = ErzaDataManager.DataSfx;
        ErzaAudioManager.Instance.SetMusicVolume(sliderMusic.value);
        ErzaAudioManager.Instance.SetSfxVolume(sliderSfx.value);
    }


    public void OnOptionClick()
    {
        panelMain.SetActive(false);
        panelOption.SetActive(true);
    }

    public void OnOptionClickExit()
    {
        panelMain.SetActive(true);
        panelOption.SetActive(false);
    }

    public void OnPlayClick(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void SetMusicVolume(float volume)
    {
        ErzaDataManager.DataMusic = volume;
        ErzaAudioManager.Instance.SetMusicVolume(volume);
       
    }

    public void SetSfxVolume(float volume)
    {
        ErzaDataManager.DataSfx = volume;
        ErzaAudioManager.Instance.SetSfxVolume(volume);
       
    }
    public void OnExitClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL("https://unity.com/");
#else
        Application.Quit();
#endif
    }

}
