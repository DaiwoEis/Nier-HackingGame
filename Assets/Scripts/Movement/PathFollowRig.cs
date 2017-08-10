using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PathFollowRig : FunctionBehaviour 
{
    private Rigidbody _rigidbody = null;

    [SerializeField]
    private float _moveSpeed = 10f;

    [SerializeField]
    private Transform[] _wayPoints = null;

    private int _currWayPoint = 0;

    [SerializeField]
    private float _arriveDistance = 0.1f;

    private Vector3 _pausedVelocity = Vector3.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX |
                                 RigidbodyConstraints.FreezeRotationZ;
    }

    protected override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        Vector3 direction = PlaneUtility.Direction(_wayPoints[_currWayPoint].position - _rigidbody.position);
        _rigidbody.velocity = direction*_moveSpeed;
        //_rigidbody.MovePosition(_rigidbody.position + direction*_moveSpeed*Time.deltaTime);

        if (PlaneUtility.SqrtDistance(transform.position, _wayPoints[_currWayPoint].position) <
            _arriveDistance * _arriveDistance)
        {
            _currWayPoint = (_currWayPoint + 1) % _wayPoints.Length;
        }
    }

    protected override void OnPause()
    {
        base.OnPause();

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = true;
    }

    protected override void OnResume()
    {
        base.OnResume();

        _rigidbody.isKinematic = false;
        _rigidbody.velocity = _pausedVelocity;
    }

    protected override void OnEnd()
    {
        base.OnEnd();

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.isKinematic = true;
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
