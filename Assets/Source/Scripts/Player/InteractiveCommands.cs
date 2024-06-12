using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class InteractiveCommands : MonoBehaviour
{
    [SerializeField] private GameObject _playerMessageInteractive;
    [SerializeField] private Transform[] _teleportPoints;
    [SerializeField] private CharacterController _playerController;
    [SerializeField] private CanvasGroup _canvasGroup;
    [Space]
    [SerializeField] private float _speed;
    [SerializeField] private float _timeWait;

    private bool _isShowBlackScreen;

    public void ShowInteractiveMessage()
    {
        _playerMessageInteractive.SetActive(true);
    }
    public void HideInteractiveMessage()
    {
        _playerMessageInteractive.SetActive(false);
    }

    public IEnumerator ShowBlackScreen(bool playerOnTower)
    {
        while (_canvasGroup.alpha < 1f)
        {
            _isShowBlackScreen = true;
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

        _isShowBlackScreen = false;
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