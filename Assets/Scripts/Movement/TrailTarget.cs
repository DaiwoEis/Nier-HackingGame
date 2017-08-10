using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class TrailTarget : FunctionBehaviour
{
    [SerializeField]
    private Transform _target = null;

    [SerializeField]
    private float _moveSpeed = 8f;

    [SerializeField]
    private bool _updateRotation = false;

    private NavMeshAgent _navMeshAgent = null;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _moveSpeed;
        _navMeshAgent.updateRotation = _updateRotation;
    }

    protected override void OnBegin()
    {
        base.OnBegin();

        _navMeshAgent.SetDestination(_target.position);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (_target == null)
        {
            _navMeshAgent.isStopped = true;
            return;
        }
        _navMeshAgent.SetDestination(_target.position);
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

        _navMeshAgent.isStopped = true;
    }
}
