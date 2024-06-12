using System.Collections;
using UnityEngine;

public class InteractiveCommands : MonoBehaviour
{
    [SerializeField] private GameObject _playerMessageInteractive;
    [SerializeField] private GameObject _handUI;
    [SerializeField] private GameObject _crosshairUI;
    [SerializeField] private Transform[] _teleportPoints;
    [SerializeField] private CharacterController _playerController;
    [SerializeField] private CanvasGroup _canvasGroup;
    [Space]
    [SerializeField] private float _speed;
    [SerializeField] private float _timeWait;

    public void ShowInteractiveMessage()
    {
        _playerMessageInteractive.SetActive(true);
        _handUI.SetActive(true);
        _crosshairUI.SetActive(false);
    }
    public void HideInteractiveMessage()
    {
        _playerMessageInteractive.SetActive(false);
        _handUI.SetActive(false);
        _crosshairUI.SetActive(true);
    }

    public IEnumerator ShowBlackScreen(bool playerOnTower)
    {
        while (_canvasGroup.alpha < 1f)
        {
            _canvasGroup.alpha += _speed;
            yield return new WaitForSeconds(_timeWait);
        }

        if (playerOnTower is false)
        {
            _playerController.transform.position = _teleportPoints[0].position;
        }
        else
        {
            _playerController.transform.position = _teleportPoints[1].position;
        }

        StartCoroutine(HideBlackScreen());
    }

    private IEnumerator HideBlackScreen()
    {
        while (_canvasGroup.alpha > 0f)
        {
            _canvasGroup.alpha -= _speed;
            yield return new WaitForSeconds(_timeWait);
        }
        _playerController.enabled = true;
    }
}