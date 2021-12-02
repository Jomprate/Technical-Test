using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Static Region

    private static SoundManager _instance;

    public static SoundManager Instance
    {
        get{
            if (_instance != null) return _instance;
            _instance = FindObjectOfType<SoundManager>();
            if (_instance == null) {
                _instance = new GameObject("Spawned SoundManager", typeof(SoundManager))
                    .GetComponent<SoundManager>();
            }

            return _instance;
        }
        private set => _instance = value;
    }


    #endregion

    #region Fields

    private AudioSource _musicSource;
    private AudioSource _musicSource2;
    private AudioSource _sfxSource;

    private bool _fmsPlaying;
    
    #endregion

    private void Awake()
    {
        _musicSource = this.gameObject.AddComponent<AudioSource>();
        _musicSource2 = this.gameObject.AddComponent<AudioSource>();
        _sfxSource = this.gameObject.AddComponent<AudioSource>();

        _musicSource.loop = true;
        _musicSource2.loop = true;
    }

    public void PlayMusic(AudioClip musicClip)
    {
        AudioSource activeSource = (_fmsPlaying) ? _musicSource : _musicSource2;
        
        activeSource.clip = musicClip;
        activeSource.volume = 1;
        activeSource.Play();
    }

    public void PlayMusicWithFade(AudioClip newClip,float transitionTime = 1.0f)
    {
        AudioSource activeSource = (_fmsPlaying) ? _musicSource : _musicSource2;
        StartCoroutine(UpdateMusicWithFade(activeSource, newClip, transitionTime));

    }

    public void PlayMusicWithCrossFade(AudioClip musicClip, float transitionTime = 1.0f)
    {
        AudioSource activeSource = (_fmsPlaying) ? _musicSource : _musicSource2;
        AudioSource newSource = (_fmsPlaying) ? _musicSource2 : _musicSource;

        _fmsPlaying = !_fmsPlaying;

        newSource.clip = musicClip;
        newSource.Play();
        StartCoroutine(UpdateMusicWithCrossFade(activeSource, newSource, transitionTime));
    }

    private IEnumerator UpdateMusicWithFade(AudioSource activeSource, AudioClip newClip, float transitionTime)
    {
        if (!activeSource.isPlaying)
            activeSource.Play();

        float t = 0.0f;
        
        //Fade Out
        for (t = 0; t < transitionTime; t+= Time.deltaTime)
        {
            activeSource.volume = (1 - (t / transitionTime));
            yield return null;
        }
        
        activeSource.Stop();
        activeSource.clip = newClip;
        activeSource.Play();
        
        //Fade in
        for (t = 0; t < transitionTime; t+= Time.deltaTime)
        {
            activeSource.volume = (t / transitionTime);
            yield return null;
        }
    }
    private IEnumerator UpdateMusicWithCrossFade(AudioSource original, AudioSource newSource, float transitionTime)
    {

        float t = 0.0f;
        
        //Fade Out
        for (t = 0; t < transitionTime; t+= Time.deltaTime)
        {
            original.volume = (1 - (t / transitionTime));
            newSource.volume = (t / transitionTime);
            yield return null;
        }
        
        original.Stop();
        
    }
    
    public void PlaySFX(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }

    public void PlaySFX(AudioClip clip, float volume)
    {
        _sfxSource.PlayOneShot(clip,volume);
    }

    public void SetMusicVolume(float volume)
    {
        _musicSource.volume = volume;
        _musicSource2.volume = volume;
    }
    public void SetSFXVolume(float volume)
    {
        _sfxSource.volume = volume;
    }
    
}
