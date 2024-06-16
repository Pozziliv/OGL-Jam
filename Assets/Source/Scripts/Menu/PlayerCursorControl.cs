using UnityEngine;

public class PlayerCursorControl : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    private void Start()
    {
        ActivatePlayerCursor();
    }

    public void ActivatePlayerCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        _playerController.enabled = false;
        Time.timeScale = 0f;
    }

    public void DeactivatePlayerCursor()
    {
        _playerController.enabled = true;
        Time.timeScale = 1f;
    }
}