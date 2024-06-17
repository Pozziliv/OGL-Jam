using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    [Header("Main Menu UI")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _settingWindow;
    [SerializeField] private Slider _slider;
    [SerializeField] private int _indexOfScene;
    [SerializeField] private AudioSource _menuAudio; 
    [Space]
    [Header("Game UI")]
    [SerializeField] private GameObject _activeWindow;
    [SerializeField] private PlayerCursorControl _playerCursorControl;
    [SerializeField] private bool _isPlayerMainUI;
    [Space]
    [SerializeField] private GameObject _imageObject;
    [SerializeField] private Image _imageHolder;
    [SerializeField] private TMP_Text _textForPicture;
    [SerializeField] private string _pictureText;

    private Sprite _selectedPicture;

    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadSceneByID()
    {
        SceneManager.LoadScene(_indexOfScene);

        FindObjectOfType<AudioManager>().StopAllPlayers();
    }

    public void ShowSettings()
    {
        _settingWindow.SetActive(true);
    }

    public void HideSettings()
    {
        _settingWindow.SetActive(false);
    }

    public void SetNewSensitivity()
    {
        _playerController.SetSensitivity(_slider.value);
    }

    public void HideActiveWindow()
    {
        _activeWindow.SetActive(false);

        if (_isPlayerMainUI)
        {
            _playerCursorControl.DeactivatePlayerCursor();
        }
    }

    public void ShowActiveWindow()
    {
        _activeWindow.SetActive(true);
    }

    public void ShowSelectedPicture()
    {
        _imageObject.SetActive(true);
        _textForPicture.text = _pictureText;
        _selectedPicture = gameObject.GetComponent<Image>().sprite;
        _imageHolder.sprite = _selectedPicture;     
    }

    public void ChangeMusicVolume()
    {
        var slider = gameObject.GetComponent<Slider>();
        _menuAudio.volume = slider.value;
    }
}