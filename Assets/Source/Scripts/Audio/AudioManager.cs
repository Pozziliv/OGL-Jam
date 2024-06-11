using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] _sounds;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (var sound in _sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;

            sound.source.playOnAwake = false;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound.name == name);
        if (s == null) 
        {
            return;
        }
        s.source.Play();
    }
}
