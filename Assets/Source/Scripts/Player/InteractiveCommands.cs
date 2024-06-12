using UnityEngine;

public class InteractiveCommands : MonoBehaviour
{
    [SerializeField] private GameObject _playerMessageInteractive;
    [SerializeField] private Transform[] _teleportPoints;

    public void ShowInteractiveMessage()
    {
        _playerMessageInteractive.SetActive(true);
    }
    public void HideInteractiveMessage()
    {
        _playerMessageInteractive.SetActive(false);
    }

    public void TeleportPlayerUp(Transform playerTransform)
    {
        playerTransform.position = _teleportPoints[0].position;
    }

    public void TeleportPlayerBack(Transform playerTransform)
    {
        playerTransform.position = _teleportPoints[1].position;
    }
}