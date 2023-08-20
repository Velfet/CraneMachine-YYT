using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private Dictionary<MyEnum.AudioSource, AudioSource> _audioSourceDictionary;
    private Dictionary<MyEnum.Sound_SFX, AudioClip> _soundDictionary_SFX;
    private Dictionary<MyEnum.Sound_BGM, AudioClip> _soundDictionary_BGM;

    public static AudioManager audioManager;

    private void Awake() {
        _audioSourceDictionary = new Dictionary<MyEnum.AudioSource, AudioSource>();
        _soundDictionary_SFX = new Dictionary<MyEnum.Sound_SFX, AudioClip>();
        _soundDictionary_BGM = new Dictionary<MyEnum.Sound_BGM, AudioClip>();

        Array audioTypes = Enum.GetValues(typeof(MyEnum.AudioSource));
        foreach(MyEnum.AudioSource audioType in audioTypes)
        {
            AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
            audioSource.volume = 0f;
            audioSource.playOnAwake = false;

            _audioSourceDictionary[audioType] = audioSource;
        }
        _audioSourceDictionary[MyEnum.AudioSource.SFX_Loop].loop = true;
        _audioSourceDictionary[MyEnum.AudioSource.BGM].loop = true;


        //Set up sfx clips
        Array soundTypes_SFX = Enum.GetValues(typeof(MyEnum.Sound_SFX));
        foreach (MyEnum.Sound_SFX type in soundTypes_SFX)
        {
            AudioClip clip = Resources.Load<AudioClip>("Audio/SFX/" + type);
            _soundDictionary_SFX[type] = clip;
            //Debug.LogWarning("SFX clip name: " + clip.name);
        }

        //Set up bgm clips
        Array soundTypes_BGM = Enum.GetValues(typeof(MyEnum.Sound_BGM));
        foreach (MyEnum.Sound_BGM type in soundTypes_BGM)
        {
            AudioClip clip = Resources.Load<AudioClip>("Audio/BGM/" + type);
            _soundDictionary_BGM[type] = clip;
            //Debug.LogWarning("BGM clip name: " + clip.name);
        }

        if(audioManager != null)
        {
            if(audioManager != this)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            audioManager = this;
            DontDestroyOnLoad(this);
        }
    }

    public void PlayOneShot(MyEnum.Sound_SFX theSound)
    {
        _audioSourceDictionary[MyEnum.AudioSource.OneShot].PlayOneShot(_soundDictionary_SFX[theSound]);
    }

    public void PlaySFX(MyEnum.Sound_SFX theSound)
    {
        _audioSourceDictionary[MyEnum.AudioSource.SFX].clip = _soundDictionary_SFX[theSound];
        _audioSourceDictionary[MyEnum.AudioSource.SFX].Play();
    }

    public void PlaySFX_Loop(MyEnum.Sound_SFX theSound)
    {
        if(_audioSourceDictionary[MyEnum.AudioSource.SFX_Loop].isPlaying == false)
        {
            _audioSourceDictionary[MyEnum.AudioSource.SFX_Loop].clip = _soundDictionary_SFX[theSound];
            _audioSourceDictionary[MyEnum.AudioSource.SFX_Loop].Play();
        }   
    }

    public void StopSFX_Loop()
    {
        if(_audioSourceDictionary[MyEnum.AudioSource.SFX_Loop].isPlaying == true)
        {
            _audioSourceDictionary[MyEnum.AudioSource.SFX_Loop].Stop();
        }
    }

    public void PlayBGM(MyEnum.Sound_BGM theSound)
    {
        _audioSourceDictionary[MyEnum.AudioSource.BGM].clip = _soundDictionary_BGM[theSound];
        _audioSourceDictionary[MyEnum.AudioSource.BGM].Play();
    }

    public void UpdateSFXVolume(float newVol)
    {
        _audioSourceDictionary[MyEnum.AudioSource.OneShot].volume = newVol;
        _audioSourceDictionary[MyEnum.AudioSource.SFX].volume = newVol;
        _audioSourceDictionary[MyEnum.AudioSource.SFX_Loop].volume = newVol;
    }

    public void UpdaetBGMVolume(float newVol)
    {
        _audioSourceDictionary[MyEnum.AudioSource.BGM].volume = newVol;
    }

    public AudioSource GetAudioSource(MyEnum.AudioSource theType)
    {
        return _audioSourceDictionary[theType];
    }

    public AudioClip GetAudioSFXClip(MyEnum.Sound_SFX theSound)
    {
        return _soundDictionary_SFX[theSound];
    }

    public AudioClip GetAudioBGMClip(MyEnum.Sound_BGM theSound)
    {
        return _soundDictionary_BGM[theSound];
    }
}
