using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VagueTrail : FunctionBehaviour
{
    [SerializeField]
    private float _initSpeed = 5f;

    [SerializeField]
    private float _attactMinSpeed = 1f;

    [SerializeField]
    private float _attractMaxSpeed = 5f;

    [SerializeField]
    private float _canTrailDistance = 10f;

    private Rigidbody _rigidbody = null;

    [SerializeField]
    private string _targetTag = "";

    private Transform _target = null;

    private void Awake()
    {
        _target = GameObject.FindWithTag(_targetTag).transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnExecute()
    {
        base.OnExecute();

        _rigidbody.velocity = transform.forward*_initSpeed;
    }

    protected override void OnPause()
    {
        base.OnPause();

        _rigidbody.isKinematic = true;
    }

    protected override void OnResume()
    {
        base.OnResume();

        _rigidbody.isKinematic = false;
    }

    protected override void OnEnd()
    {
        base.OnEnd();

        _rigidbody.velocity = Vector3.zero;
    }

    protected override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        float t = PlaneDistanceUtility.Distance(transform.position, _target.position)/_canTrailDistance;
        t = Mathf.Clamp01(t);
        t = 1f - t;
        float attractSpeed = Mathf.Lerp(_attactMinSpeed, _attractMaxSpeed, t);
        Vector3 direction = _target.position - transform.position;
        direction.y = 0f;
        direction.Normalize();
        _rigidbody.velocity = _rigidbody.velocity + direction*attractSpeed;
        //if (_rigidbody.velocity.sqrMagnitude > _maxSpeed*_maxSpeed)
        //{
        //    _rigidbody.velocity = _rigidbody.velocity.normalized*_maxSpeed;
        //}
    }
}
