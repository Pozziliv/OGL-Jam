using UnityEngine;

public class PlayerCursorControl : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;

    public void ActivatePlayerCursor()
    {
        _playerController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;    
        //Time.timeScale = 0f;
    }

    public void DeactivatePlayerCursor()
    {
        _playerController.enabled = true;
        Time.timeScale = 1f;
    }
}