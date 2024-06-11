using UnityEngine;

public class InteractiveCommands : MonoBehaviour
{
    [SerializeField] private GameObject _playerMessageInteractive;

    public void ShowInteractiveMessage()
    {
        _playerMessageInteractive.SetActive(true);
    }
    public void HideInteractiveMessage()
    {
        _playerMessageInteractive.SetActive(false);
    }
}