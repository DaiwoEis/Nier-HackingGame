using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RandomTrail : FunctionBehaviour
{
    [SerializeField]
    private string _targetTag = "";

    [SerializeField]
    private Transform _target = null;

    private Vector3 _trailPoint = Vector3.zero;

    [SerializeField]
    private float _randomPointRadius = 1f;

    private bool _straightMove = false;

    private Rigidbody _rigidbody = null;

    [SerializeField]
    private float _maxSpeed = 5f;

    [SerializeField]
    private float _rotationSpeed = 10f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_target == null)
        {
            _target = GameObject.FindWithTag(_targetTag).transform;
        }
    }

    protected override void OnExecute()
    {
        base.OnExecute();
        _trailPoint = GetRandomPoint();
    }

    protected override void OnEnd()
    {
        base.OnEnd();
        _rigidbody.velocity = Vector3.zero;
    }

    protected override void OnFixedUpdate()
    {
        if (!_straightMove)
        {
            _straightMove = PlaneUtility.SqrtDistance(transform.position, _trailPoint) < 0.09f;
        }

        if (!_straightMove)
        {
            Vector3 toTarget = _trailPoint - transform.position;
            toTarget.y = 0f;
            toTarget.Normalize();
            float speed = (1f - Vector3.Angle(transform.forward, toTarget)/180f)*_maxSpeed;

            _rigidbody.velocity = transform.forward*speed;

            _rigidbody.rotation = Quaternion.Lerp(_rigidbody.rotation, Quaternion.LookRotation(toTarget),
                _rotationSpeed*Time.deltaTime);
        }
        else
        {
            _rigidbody.velocity = transform.forward*_maxSpeed;
        }
    }

    private Vector3 GetRandomPoint()
    {
        Vector3 randomPoint = Random.insideUnitSphere;
        randomPoint = (randomPoint - Vector3.one)*0.5f;
        randomPoint.y = 0f;
        randomPoint *= _randomPointRadius;
        return randomPoint + _target.position;
    }

    private bool ExceedTarget()
    {
        return transform.InverseTransformPoint(_target.position).z < 0f ||
               transform.InverseTransformPoint(_trailPoint).z < 0f;
    }

    private void OnDrawGizmos()
    {
        if (_trailPoint != Vector3.zero)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_trailPoint, 0.3f);
        }
    }
}
