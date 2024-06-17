using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _dialogueSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;

    [SerializeField] private AudioMixer _masterMixer;

    private void Start()
    {
        _masterSlider.onValueChanged.AddListener(ChangeMasterVolume);
        _dialogueSlider.onValueChanged.AddListener(ChangeDialogueVolume);
        _musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        _soundSlider.onValueChanged.AddListener(ChangeSoundVolume);
    }

    private void ChangeMasterVolume(float volume)
    {
        _masterMixer.SetFloat("MasterVolume", volume);
    }
    private void ChangeDialogueVolume(float volume)
    {
        _masterMixer.SetFloat("DialoguesVolume", volume);
    }
    private void ChangeMusicVolume(float volume)
    {
        _masterMixer.SetFloat("MusicVolume", volume);
    }
    private void ChangeSoundVolume(float volume)
    {
        _masterMixer.SetFloat("SoundsVolume", volume);
    }
}
