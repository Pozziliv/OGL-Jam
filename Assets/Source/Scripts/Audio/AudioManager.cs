using UnityEngine;
using UnityEngine.Audio;
using System;
using System.Collections;
using Unity.VisualScripting;
using System.Linq;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] _sounds;

    [SerializeField] private AnimationCurve _silenceCurve;

    public static AudioManager instance;

    public bool hasSubs = true;

    private void Awake()
    {
        if (instance == null)
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

            sound.source.outputAudioMixerGroup = sound.mixer;

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
        s.source.volume = s.volume;

        if (s.soloVoice is true)
        {
            foreach (var sound in _sounds.Where(x => x.source.isPlaying is true))
            {
                if (sound.soloVoice is true)
                {
                    sound.source.Stop();
                }
            }
        }

        s.source.Play();

        if (s.hasSubtitle && hasSubs is true)
        {
            FindObjectOfType<SubtitlesManager>().StartSubtitles(s.name);
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }

        StartCoroutine(SilenceAudio(s.source, 3f));
    }

    private IEnumerator SilenceAudio(AudioSource audioSource, float time)
    {
        float progress = 0f;
        float startVolume = audioSource.volume;

        while (progress < 1f)
        {
            progress += Time.deltaTime / time;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, progress);

            yield return null;
        }

        audioSource.Stop();
    }
}
