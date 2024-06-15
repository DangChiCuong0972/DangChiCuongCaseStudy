using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("MyScript/MyAudioManager")]
public class MyAudioManager : MonoBehaviour
{
    public static MyAudioManager Instance
    {
        get => instance;
    }
    private static MyAudioManager instance;

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
        SetMusic(backgroundMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void SetSfxSource(AudioClip clip)
    {
        
        sfxSource.PlayOneShot(clip);
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
