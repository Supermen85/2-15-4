using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _speed = 5.0f;

    private Rigidbody _rigidbody;
    private Transform _currentWaypoint;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentWaypoint = GetRandomWaypoint();
    }

    private Transform GetRandomWaypoint()
    {
        Transform nextWaypoint = _waypoints[Random.Range(0, _waypoints.Length)];
        
        while (nextWaypoint == _currentWaypoint)
            nextWaypoint = _waypoints[Random.Range(0, _waypoints.Length)];

        return nextWaypoint;
    }

    private void Update()
    {
        float directionX = _currentWaypoint.position.x - transform.position.x;
        float directionZ = _currentWaypoint.position.z - transform.position.z;

        Vector3 direction = new Vector3(directionX, 0f, directionZ).normalized;
        _rigidbody.velocity = new Vector3(direction.x * _speed, _rigidbody.velocity.y, direction.z * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Waypoint>() == null)
            return;

        if (other != _currentWaypoint.GetComponent<Collider>())
            return;

        _currentWaypoint = GetRandomWaypoint();
    }
}
