using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KasaAudioManager : MonoBehaviour
{

    public static KasaAudioManager Instance
    {
        get => instance;
    }
    private static KasaAudioManager instance;

    public AudioSource musicSource;

    public AudioSource sfxSource;

    public AudioSource skillQ2Source;

    public AudioSource skillQ3BulletSource;
    public AudioClip musicBackground;


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
        SetMusicScource(musicBackground);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void SetMusicScource(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }
    
    public void SetSfxScource(AudioClip clip)
    { 
        sfxSource.PlayOneShot(clip);
    }
   
    public void SetSkillQ2Source(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void SetBulletQ3(AudioClip clip)
    {
        skillQ3BulletSource.PlayOneShot(clip);

    }

    public void SetVoulumeMusic(float volume)
    {
        musicSource.volume = volume;
    }
    public void SetSfxVolume(float volume)
    {
        sfxSource.volume = volume;
    }
    public void SetVolumeBullet(float volume)
    {
        skillQ3BulletSource.volume = volume;
    }
   
}
