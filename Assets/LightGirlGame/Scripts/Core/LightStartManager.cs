using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[AddComponentMenu("LightScript/LightStartManager")]
public class LightStartManager : MonoBehaviour
{

    public GameObject panelMain;
    public GameObject panelOption;

    public Slider sliderMusic;
    public Slider sliderSfx;
    // Start is called before the first frame update
    void Start()
    {
        sliderMusic.value = LightDataManager.DataMusic;
        sliderSfx.value = LightDataManager.DataSfx;
        panelMain.SetActive(true);
        panelOption.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void OnclickPlay(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void OnclickOption()
    {
        panelMain.SetActive(false);
        panelOption.SetActive(true);
    }
    public void OnclickOptionExit()
    {
        panelMain.SetActive(true);
        panelOption.SetActive(false);
    }

    public void SetMusicVolume(float volume)
    {
        LightDataManager.DataMusic = volume;
        LightAudioManager.Instance.SetMusicVolume(volume);
    }

    public void SetSfxVolume(float volume)
    {

        LightDataManager.DataSfx = volume;
        LightAudioManager.Instance.SetSfxVolume(volume);
    }
}
