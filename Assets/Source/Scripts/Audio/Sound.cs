using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;

    public AudioMixerGroup mixer;

    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 3f)]
    public float pitch;

    public bool hasSubtitle;

    public bool soloVoice;

    [HideInInspector]
    public AudioSource source;
}
