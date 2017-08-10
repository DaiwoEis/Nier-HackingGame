using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BounceWall : FunctionBehaviour
{
    private Rigidbody _rigidbody = null;

    [SerializeField]
    private float _moveSpeed = 10f;

    private Vector3 _moveDirection = Vector3.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnBegin()
    {
        base.OnBegin();

        _moveDirection = transform.forward;
    }

    protected override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        _rigidbody.velocity = _moveDirection*_moveSpeed;
    }

    protected override void OnPause()
    {
        base.OnPause();

        _rigidbody.velocity = Vector3.zero;
    }

    protected override void OnEnd()
    {
        base.OnEnd();

        _rigidbody.velocity = Vector3.zero;
    }

    protected override void WhenCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag(TagConfig.Wall))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, _moveDirection, out hitInfo, transform.lossyScale.x + 0.1f))
            {
                _moveDirection = Vector3.Reflect(_moveDirection, hitInfo.normal);
            }
            else
            {
                _moveDirection = -_moveDirection;
            }
        }
    }
}
