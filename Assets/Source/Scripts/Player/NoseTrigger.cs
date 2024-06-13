using UnityEngine;

public class NoseTrigger : MonoBehaviour
{
    [SerializeField] private InteractiveCommands _interactiveCommands;
    [SerializeField] private CharacterController _player;

    private bool _playerOnTower;
    private bool _playerAttemptClimp;
    private bool _playerWithDino;
    private bool _playerWithDinoAlreadyInterracted;

    private void Update()
    {
        if (_playerAttemptClimp is true && Input.GetKeyDown(KeyCode.E) && _playerOnTower is false)
        {
            _player.enabled = false;
            StartCoroutine(_interactiveCommands.ShowBlackScreen(_playerOnTower));
            _playerOnTower = true;
            _playerAttemptClimp = false;

            FindObjectOfType<AudioManager>().Play("TowerAmbient");
        }
        else if (_playerAttemptClimp is true && Input.GetKeyDown(KeyCode.E) && _playerOnTower)
        {
            _player.enabled = false;
            StartCoroutine(_interactiveCommands.ShowBlackScreen(_playerOnTower));
            _playerOnTower = false;
            _playerAttemptClimp = false;

            FindObjectOfType<AudioManager>().Stop("TowerAmbient");
        }
        else if(_playerWithDino is true && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<Dino>().Interract();
            _playerWithDinoAlreadyInterracted = true;
            _interactiveCommands.HideInteractiveMessage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stairs")
        {
            _playerAttemptClimp = true;
            _interactiveCommands.ShowInteractiveMessage();
        }
        else if (other.tag == "Dino" && _playerWithDinoAlreadyInterracted is false)
        {
            _playerWithDino = true;
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
        else if (other.tag == "Dino")
        {
            _playerWithDino = false;
            _interactiveCommands.HideInteractiveMessage();
        }
    }
}
