using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[AddComponentMenu("MyScript/MyStartManager")]
public class MyStartManager : MonoBehaviour
{
    public GameObject panelMain;
    public GameObject panelOption;

    public Slider sliderMusic;
    public Slider sliderSfx;

    // Start is called before the first frame update
    void Start()
    {
        GetDataVolume();
        panelMain.SetActive(true);
        panelOption.SetActive(false);
       

    }

    private void GetDataVolume()
    {
        sliderMusic.value = DataManager.DataMusic;
        sliderSfx.value = DataManager.DataSfx;

        MyAudioManager.Instance.SetMusicVolume(sliderMusic.value);
        MyAudioManager.Instance.SetSfxVolume(sliderSfx.value);
    }

    public void OnclickPlay(string name)
    {
        SceneManager.LoadScene(name);
    }    

    public void OnclickOption()
    {
        panelMain.SetActive(false);
        panelOption.SetActive(true);
    }

    public void OnClickOptionExit()
    {
        panelMain.SetActive(true);
        panelOption.SetActive(false);
    }

    public void SetMusicVolume(float volume)
    {
        DataManager.DataMusic = volume;
        MyAudioManager.Instance.SetMusicVolume(volume);
    }

    public void SetSfxVolume(float volume)
    {
        DataManager.DataSfx = volume;
        MyAudioManager.Instance.SetSfxVolume(volume);
    }

    public void OnclickExitMain()
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
