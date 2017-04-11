using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BounceWall : FunctionBehaviour
{
    private Rigidbody _rigidbody = null;

    [SerializeField]
    private float _moveSpeed = 10f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start() { }

    protected override void OnExecute()
    {
        base.OnExecute();

        _rigidbody.velocity = transform.forward*_moveSpeed;
    }

    protected override void OnFixedUpdate()
    {
        base.OnFixedUpdate();

        _rigidbody.velocity = transform.forward*_moveSpeed;
    }

    protected override void onCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag(TagConfig.Wall))
        {
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, transform.lossyScale.x + 0.1f))
            {
                transform.forward = Vector3.Reflect(transform.forward, hitInfo.normal);
            }
            else
            {
                transform.forward = -transform.forward;
            }
            _rigidbody.velocity = transform.forward*_moveSpeed;
        }
    }
}
