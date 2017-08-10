using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class StraightMove : FunctionBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;

    [HideInInspector]
    public float moveSpeed { get { return _moveSpeed; } set { _moveSpeed = value; } }
    
    private Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX |
                                 RigidbodyConstraints.FreezeRotationZ;
        _rigidbody.useGravity = false;
    }

    protected override void OnBegin()
    {
        base.OnBegin();

        _rigidbody.velocity = transform.forward*_moveSpeed;
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
        _rigidbody.velocity = transform.forward * _moveSpeed;
    }
}
