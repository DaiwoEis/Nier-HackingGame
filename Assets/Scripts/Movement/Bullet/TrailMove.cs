using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TrailMove : FunctionBehaviour
{
    [SerializeField]
    private string _targetTag = "";
    public string tagetTag { get { return _targetTag; } set { _targetTag = value; } }

    [SerializeField]
    private float _initSpeed = 5f;
    public float initSpeed { get { return _initSpeed; } set { _initSpeed = value; } }

    [SerializeField]
    private float _attractForce = 10f;
    public float attractForce { get { return _attractForce; } set { _attractForce = value; } }

    private Rigidbody _rigidbody = null;

    private Vector3 _initVelocity = Vector3.zero;

    private Vector3 _attractAcceleration = Vector3.zero;

    private Vector3 _pasuedVelocity = Vector3.zero;

    private Transform _target = null;

    private float _timer = 0f;

    private void Awake()
    {        
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnBegin()
    {
        base.OnBegin();

        _target = GameObject.FindWithTag(_targetTag).transform;
        _timer = 0f;

        _initVelocity = transform.forward*_initSpeed;
        _attractAcceleration = PlaneUtility.Direction(_target.position - transform.position)*_attractForce;
    }

    protected override void OnPause()
    {
        base.OnPause();

        _pasuedVelocity = _rigidbody.velocity;
        _rigidbody.isKinematic = true;
    }

    protected override void OnResume()
    {
        base.OnResume();

        _rigidbody.isKinematic = false;
        _rigidbody.velocity = _pasuedVelocity;
    }

    protected override void OnEnd()
    {
        base.OnEnd();

        _rigidbody.velocity = Vector3.zero;
        _timer = 0f;
    }

    protected override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        _timer += Time.deltaTime;
        _rigidbody.velocity = _initVelocity + _attractAcceleration*_timer;
    }
}
