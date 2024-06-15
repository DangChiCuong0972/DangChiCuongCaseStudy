using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("LightScript/LightAudioManager")]
public class LightAudioManager : MonoBehaviour
{
    public static LightAudioManager Instance
    {
        get => instance;
    }
    private static LightAudioManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip backgroundMusic;

    private void Awake()
    {
        if(instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }



    // Start is called before the first frame update
    void Start()
    {
        SetMusicSource(backgroundMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusicSource(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.volume = 0.5f;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void SetSfxSource(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
        sfxSource.clip = clip;
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SetSfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }

}
