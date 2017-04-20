using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PathFollow : FunctionBehaviour
{
    private NavMeshAgent _navMeshAgent = null;

    [SerializeField]
    private Transform[] _wayPoints = null;

    [SerializeField]
    private bool _updateRotate = true;

    private int _currWayPoint = 0;

    [SerializeField]
    private float _arriveDistance = 0.5f;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = _updateRotate;
    }

    protected override void OnUpdate()
    {
        if (PlaneUtility.SqrtDistance(transform.position, _wayPoints[_currWayPoint].position) <
            _arriveDistance*_arriveDistance)
        {
            _currWayPoint = (_currWayPoint + 1)%_wayPoints.Length;
            _navMeshAgent.SetDestination(_wayPoints[_currWayPoint].position);
        }
    }

    protected override void OnExecute()
    {
        if (_navMeshAgent == null)
            _navMeshAgent = GetComponent<NavMeshAgent>();

        _navMeshAgent.SetDestination(_wayPoints[_currWayPoint].position);
    }

    protected override void OnPause()
    {
        base.OnPause();

        _navMeshAgent.isStopped = true;
    }

    protected override void OnResume()
    {
        base.OnResume();

        _navMeshAgent.isStopped = false;
    }

    protected override void OnEnd()
    {
        base.OnEnd();

        _navMeshAgent.ResetPath();
        _navMeshAgent.velocity = Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        if (_currWayPoint < _wayPoints.Length && _wayPoints[_currWayPoint] != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_wayPoints[_currWayPoint].position, 0.3f);
        }
    }
}
