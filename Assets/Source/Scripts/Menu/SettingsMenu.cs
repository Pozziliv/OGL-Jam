using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _dialogueSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Slider _sensSlider;

    [SerializeField] private Toggle _muteSubsToggle;

    [SerializeField] private AudioMixer _masterMixer;

    private void Start()
    {
        _masterSlider.onValueChanged.AddListener(ChangeMasterVolume);
        _dialogueSlider.onValueChanged.AddListener(ChangeDialogueVolume);
        _musicSlider.onValueChanged.AddListener(ChangeMusicVolume);
        _soundSlider.onValueChanged.AddListener(ChangeSoundVolume);
        _sensSlider.onValueChanged.AddListener(SetNewSensitivity);

        _sensSlider.value = FindObjectOfType<PlayerController>().GetSensitivity();

        _muteSubsToggle.isOn = FindObjectOfType<AudioManager>().hasSubs;
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

    public void HasSubtitle()
    {
        FindObjectOfType<AudioManager>().hasSubs = _muteSubsToggle.isOn;
    }

    public void SetNewSensitivity(float value)
    {
        FindObjectOfType<PlayerController>().SetSensitivity(value);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);

        FindObjectOfType<AudioManager>().StopAllPlayers();
    }
}
