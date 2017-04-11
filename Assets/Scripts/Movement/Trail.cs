using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Trail : FunctionBehaviour
{
    [SerializeField]
    private Transform _target = null;

    private NavMeshAgent _navMeshAgent = null;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start() { }

    protected override void OnExecute()
    {
        base.OnExecute();

        _navMeshAgent.SetDestination(_target.position);
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        _navMeshAgent.SetDestination(_target.position);
    }

    protected override void OnPause()
    {
        base.OnPause();

        _navMeshAgent.Stop();
    }

    protected override void OnResume()
    {
        base.OnResume();

        _navMeshAgent.Resume();
    }
}
