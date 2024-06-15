using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KasaStartManager : MonoBehaviour
{
    public Slider sliderMusic;
    public Slider sliderSfx;

    public GameObject panelMain;
    public GameObject panelOption;
    public GameObject panelTutorial;

    // Start is called before the first frame update
    void Start()
    {
        panelMain.SetActive(true);
        panelOption.SetActive(false);
        panelTutorial.SetActive(false);
        sliderMusic.value = KasaAudioManager.Instance.musicSource.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetvolumeMusic(float volume)
    {
        KasaAudioManager.Instance.SetVoulumeMusic(volume);
    }

    public void OnClickPlay(string level)
    {
        SceneManager.LoadScene(level);
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
    public void OnClickTutorial()
    {
        panelMain.SetActive(false);
        panelTutorial.SetActive(true);
        
    }

    public void OnClickExitTuorial()
    {
        panelMain.SetActive(true);
        panelTutorial.SetActive(false);
    }

    public void OnclickExitMenu()
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
