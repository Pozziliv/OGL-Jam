using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [Header("Main Menu UI")]
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private GameObject _settingWindow;
    [SerializeField] private Slider _slider;
    [SerializeField] private int _indexOfScene;
    [Space]
    [Header("Game UI")]
    [SerializeField] private GameObject _activeWindow;
    [SerializeField] private PlayerCursorControl _playerCursorControl;
    
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(_indexOfScene);
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
        _playerCursorControl.DeactivatePlayerCursor();
    }

    public void ShowActiveWindow()
    {
        _activeWindow.SetActive(true);
    }
}