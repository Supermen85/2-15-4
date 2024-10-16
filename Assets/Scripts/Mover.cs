using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 5.0f;

    private Transform _currentWaypoint;

    private void Start()
    {
        _currentWaypoint = GetRandomWaypoint();
    }

    private void FixedUpdate()
    {
        Vector3 currentPosition = transform.position;
        Vector3 waypointPosition = _currentWaypoint.position;
        Vector3 direction = (waypointPosition - currentPosition).normalized;

        transform.Translate(direction * _speed * Time.deltaTime);

        float distance = 0.1f;

        if (Vector3Extensions.isEnoughClose(currentPosition, waypointPosition, distance))
            _currentWaypoint = GetRandomWaypoint();
    }

    private Transform GetRandomWaypoint()
    {
        Transform nextWaypoint;

        do
        {
            nextWaypoint = _waypoints[Random.Range(0, _waypoints.Length)];
        }
        while (nextWaypoint == _currentWaypoint);

        return nextWaypoint;
    }
}
