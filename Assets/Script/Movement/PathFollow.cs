using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PathFollow : FunctionBehaviour
{
    private NavMeshAgent _navMeshAgent = null;

    [SerializeField]
    private Transform[] _wayPoints = null;

    private int _currWayPoint = 0;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    protected override void OnUpdate()
    {
        if (PlaneDistanceUtility.IsArrive(transform.position, _wayPoints[_currWayPoint].position))
        {
            _currWayPoint = (_currWayPoint + 1)%_wayPoints.Length;
            _navMeshAgent.SetDestination(_wayPoints[_currWayPoint].position);
        }
    }

    protected override void OnExecute()
    {
        _navMeshAgent.SetDestination(_wayPoints[_currWayPoint].position);
    }

}
