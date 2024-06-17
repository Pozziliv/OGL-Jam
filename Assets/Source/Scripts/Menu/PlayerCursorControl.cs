using UnityEngine;

public class PlayerCursorControl : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private HeadBob _headBob;

    public void ActivatePlayerCursor()
    {
        _playerController.enabled = false;
        _headBob.StopAllCoroutines();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;    
        //Time.timeScale = 0f;
    }

    public void DeactivatePlayerCursor()
    {
        _playerController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //Time.timeScale = 1f;
    }
}