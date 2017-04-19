using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VagueTrail : FunctionBehaviour
{
    [SerializeField]
    private float _initSpeed = 5f;

    [SerializeField]
    private float _attractMaxForce = 10f;

    [SerializeField]
    private float _canTrailDistance = 10f;

    private Rigidbody _rigidbody = null;

    [SerializeField]
    private string _targetTag = "";

    private Vector3 _pasuedVelocity = Vector3.zero;

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
    }

    protected override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        float t = PlaneUtility.Distance(transform.position, _target.position)/_canTrailDistance;
        t = Mathf.Clamp01(t);
        t = 1f - t;
        t *= t;
        float attractForce = Mathf.Lerp(0f, _attractMaxForce, t);
        Vector3 toTarget = _target.position - transform.position;
        toTarget.y = 0f;
        toTarget.Normalize();
        _rigidbody.AddForce(toTarget*attractForce);
    }
}
