using UnityEngine;

public class NoseTrigger : MonoBehaviour
{
    [SerializeField] private InteractiveCommands _interactiveCommands;
    [SerializeField] private CharacterController _player;

    private bool _playerOnTower;
    private bool _playerAttemptClimp;

    private void Update()
    {
        if (_playerAttemptClimp is false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && _playerOnTower is false)
        {
            _player.enabled = false;
            StartCoroutine(_interactiveCommands.ShowBlackScreen(_playerOnTower));
            _playerOnTower = true;
            _playerAttemptClimp = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && _playerOnTower)
        {
            _player.enabled = false;
            StartCoroutine(_interactiveCommands.ShowBlackScreen(_playerOnTower));
            _playerOnTower = false;
            _playerAttemptClimp = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stairs")
        {
            _playerAttemptClimp = true;
            _interactiveCommands.ShowInteractiveMessage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Stairs")
        {
            _playerAttemptClimp = false;
            _interactiveCommands.HideInteractiveMessage();
        }
    }
}
