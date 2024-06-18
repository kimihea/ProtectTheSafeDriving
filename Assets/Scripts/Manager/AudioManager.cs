using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
                if (_instance == null)
                {
                    GameObject audioManager = new GameObject("AudioManager");
                    _instance = audioManager.AddComponent<AudioManager>();
                }
            }
            return _instance;
        }
    }


    AudioSource bgmAudioSource;
    AudioSource effectAudioSource;
    AudioMixer audioMixer;

    void Awake()
    {
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        InitAudioSource("bgm", ref bgmAudioSource);
        InitAudioSource("effect", ref effectAudioSource);
        ConnectAudioMixer();
        setClip("Sound/InitialD");
        PlayBGM();
    }


    // Update is called once per frame
    void Update()
    {
        if (bgmAudioSource.clip ==null)
        {
            bgmAudioSource.Stop();
        }
        if (Input.GetKeyDown(KeyCode.P))  // 'P' 키를 눌러서 BGM 재생/정지 토글
        {
            if (bgmAudioSource.isPlaying)
            {
                bgmAudioSource.Pause();
            }
            else
            {
                bgmAudioSource.PlayOneShot(effectAudioSource.clip);
            }
        }
    }
    public void PlayBGM()
    {
        if (bgmAudioSource.isPlaying)
        {
            bgmAudioSource.Pause();
        }
        else
        {
            bgmAudioSource.Play();
        }
    }
    public void PlayEffect(string clipName)
    {
        AudioClip clip = Resources.Load<AudioClip>(clipName);
        effectAudioSource.PlayOneShot(clip);
    }

    private void InitAudioSource(string name,ref AudioSource audiosource)
    {
        GameObject bgmObject = new GameObject(name);
        bgmObject.transform.SetParent(transform);
        audiosource = bgmObject.AddComponent<AudioSource>();
        audiosource.loop = true;
    }
    private void ConnectAudioMixer()
    {
        audioMixer = Resources.Load<AudioMixer>("NewAudioMixer");
        if (audioMixer != null)
        {
            bgmAudioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[1];
            effectAudioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[2];
        }
    }
    private void setClip(string path)
    {
        bgmAudioSource.clip = Resources.Load<AudioClip>(path);
        if (bgmAudioSource.clip == null)
        {
            Debug.Log("WrongAudioClipPleaseCheckPath");
        }
    }
    public void Mute()//it isnt exist on Volumewindow
    {
        float masterVol;
        if (audioMixer.FindMatchingGroups("Master")[0].audioMixer.GetFloat("masterVolume", out masterVol))
        {
            if (masterVol == 0f)
            {
                audioMixer.FindMatchingGroups("Master")[0].audioMixer.SetFloat("masterVolume", -80f);

            }
            else
            {
                audioMixer.FindMatchingGroups("Master")[0].audioMixer.SetFloat("masterVolume", 0f);

            }
        }
    }

}
