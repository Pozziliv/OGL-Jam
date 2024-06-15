using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _reciever;

    private bool _playerIsOverlapping = false;
    private void Update()
    {
        if (_playerIsOverlapping)
        {
            Vector3 portalToPlayer = _player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct < 0f)
            {
                // Teleport him!
                float rotationDiff = -Quaternion.Angle(transform.rotation, _reciever.rotation);
                rotationDiff += 180f;
                _player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                _player.position = _reciever.position + positionOffset;

                _playerIsOverlapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameController")
        {
            _playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "GameController")
        {
            _playerIsOverlapping = false;
        }
    }
}
