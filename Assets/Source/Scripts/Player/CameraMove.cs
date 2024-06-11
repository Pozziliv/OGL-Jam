using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField][Range(0, 15)] private float _sensitivity = 2f;
    [SerializeField] private Transform _player;
    [SerializeField] private float _verticalLover;
    [SerializeField] private float _verticalUpper;
    private float _currentVerticalAngle;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        PlayerCameraMoving();
    }

    private void PlayerCameraMoving()
    {
        var vertical = -Input.GetAxis("Mouse Y") * _sensitivity;
        var horizontal = Input.GetAxis("Mouse X") * _sensitivity;
        _currentVerticalAngle = Mathf.Clamp(_currentVerticalAngle + vertical, _verticalUpper, _verticalLover);
        transform.localRotation = Quaternion.Euler(_currentVerticalAngle, 0, 0);
        _player.Rotate(0f, horizontal, 0f);
    }
}
