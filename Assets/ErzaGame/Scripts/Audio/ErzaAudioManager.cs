using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("ErzaScript/ErzaAudioManager")]
public class ErzaAudioManager : MonoBehaviour
{

    public static ErzaAudioManager Instance
    {
        get => instance;

    }
    private static ErzaAudioManager instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip backgroundMusic;
   

    private void Awake()
    {
        if ( instance != null )
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
        PLayBackGroundMusic(backgroundMusic);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PLayBackGroundMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.volume = 0.3f;
        musicSource.Play();
    }
    public void PlaySfx(AudioClip clip)
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
