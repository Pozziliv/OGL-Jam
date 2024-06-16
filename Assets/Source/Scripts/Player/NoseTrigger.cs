using UnityEngine;

public class NoseTrigger : MonoBehaviour
{
    [SerializeField] private InteractiveCommands _interactiveCommands;
    [SerializeField] private CharacterController _player;
    [SerializeField] private GameObject _extraCanvas;
    [SerializeField] private PlayerCursorControl _playerCursorControl;

    private bool _playerOnTower;
    private bool _playerAttemptClimp;
    private bool _playerWithDino;
    private bool _playerWithDinoAlreadyInterracted;
    private bool _playerOnStartExit;
    private bool _playerWithACar;
    private bool _playerDetectedExtraMaterials;

    private void Update()
    {
        if (_playerAttemptClimp is true && Input.GetKeyDown(KeyCode.E) && _playerOnTower is false)
        {
            _player.enabled = false;
            StartCoroutine(_interactiveCommands.ShowBlackScreen(_playerOnTower));
            _playerOnTower = true;
            _playerAttemptClimp = false;

            FindObjectOfType<AudioManager>().Play("TowerAmbient");
            FindObjectOfType<QuestsManager>().SetTowerCheck();
            FindObjectOfType<TowerEndingTrigger>().StartWait();
        }
        else if (_playerAttemptClimp is true && Input.GetKeyDown(KeyCode.E) && _playerOnTower)
        {
            _player.enabled = false;
            StartCoroutine(_interactiveCommands.ShowBlackScreen(_playerOnTower));
            _playerOnTower = false;
            _playerAttemptClimp = false;

            FindObjectOfType<AudioManager>().Stop("TowerAmbient");
            FindObjectOfType<TowerEndingTrigger>().EndWait();
        }
        else if(_playerWithDino is true && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<Dino>().Interract();
            _playerWithDinoAlreadyInterracted = true;
            _interactiveCommands.HideInteractiveMessage();
        }
        else if (_playerOnStartExit is false && Input.GetKeyDown(KeyCode.E) && _playerWithACar is true)
        {
            _interactiveCommands.HideInteractiveMessage();
            FindObjectOfType<QuestsManager>().CarEnding();
            _playerOnStartExit = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && _playerDetectedExtraMaterials)
        {
            _interactiveCommands.HideInteractiveMessage();
            _playerDetectedExtraMaterials = false;
            _extraCanvas.SetActive(true);
            _playerCursorControl.ActivatePlayerCursor();
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
        else if (other.tag == "Car" && _playerOnStartExit is false)
        {
            _playerWithACar = true;
            _interactiveCommands.ShowInteractiveMessage();
        }
        else if (other.tag == "Extras")
        {
            _playerDetectedExtraMaterials = true;
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
        else if (other.tag == "Car" && _playerOnStartExit is false)
        {
            _playerWithACar = false;
            _interactiveCommands.HideInteractiveMessage();
        }
        else if (other.tag == "Extras")
        {
            _playerDetectedExtraMaterials = false;
            _interactiveCommands.HideInteractiveMessage(); 
        }
    }
}
