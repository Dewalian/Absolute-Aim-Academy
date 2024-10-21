using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    public AudioClip[] sfxSounds;

    public AudioClip[] themeSong;

     private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        musicSource.clip = themeSong[0];
        musicSource.Play();
    }

    public void PlayMusic(int index)
    {
        musicSource.clip = themeSong[index];
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlaySFX(int index)
    {
        sfxSource.PlayOneShot(sfxSounds[index]);
    }

    public void VolumeMusic(float volume)
    {
        musicSource.volume = volume;
    }

    public void VolumeSFX(float volume)
    {
        sfxSource.volume = volume;
    }
}
