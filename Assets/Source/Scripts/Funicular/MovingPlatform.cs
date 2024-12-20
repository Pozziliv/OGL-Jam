using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private BoxCollider _collider;
    [SerializeField] private WaypointPath _waypointPath;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeWait;

    [SerializeField] private int _rideIndex = 1;

    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;

    private bool _isStarted;

    public bool IsStarted() => _isStarted;

    private void Start()
    {
        TargetNextWaypoint();
    }

    private void FixedUpdate()
    {
        if (_isStarted)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        _elapsedTime += Time.deltaTime;

        float elapsedPercentage = _elapsedTime / _timeToWaypoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);
        transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elapsedPercentage);

        if (elapsedPercentage >= _timeWait)
        {
            _collider.enabled = false;
            _animator.SetBool("isClosed", false);
        }
    }

    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypoint(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        _elapsedTime = 0f;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        _collider.enabled = true;
        other.transform.SetParent(transform);
        _isStarted = true;
        _animator.SetBool("isClosed", true);

        FindObjectOfType<QuestsManager>().SetFuniculerInt(_rideIndex);
        _rideIndex += 1;
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
        _isStarted = false;
        TargetNextWaypoint();
    }
}
