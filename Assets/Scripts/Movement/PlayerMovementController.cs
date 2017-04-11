using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : FunctionBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;

    [SerializeField]
    private float _rotationSpeed = 20f;

    private Rigidbody _rigidbody = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnEnd()
    {
        base.OnEnd();

        _rigidbody.velocity = Vector3.zero;
    }

    protected override void OnUpdate()
    {
        Vector3 moveDirection;
        if (CheckMove(out moveDirection))
        {
            Vector3 rotateDirection;
            if (CheckRotate())
            {
                rotateDirection = new Vector3(Input.GetAxisRaw("RightHorizontal"), 0f, Input.GetAxisRaw("RightVertical"));
                rotateDirection.Normalize();              
            }
            else
            {
                rotateDirection = moveDirection;
            }

            transform.forward = Vector3.Lerp(transform.forward, rotateDirection, _rotationSpeed*Time.deltaTime);
            _rigidbody.velocity = moveDirection*_moveSpeed;
        }
        else
        {
            if (CheckRotate())
            {
                Vector3 rotateDirection = new Vector3(Input.GetAxisRaw("RightHorizontal"), 0f, Input.GetAxisRaw("RightVertical"));
                rotateDirection.Normalize();
                transform.forward = Vector3.Lerp(transform.forward, rotateDirection, _rotationSpeed*Time.deltaTime);
            }
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private bool CheckRotate()
    {
        return Mathf.Abs(Input.GetAxisRaw("RightVertical")) > 0.3f ||
               Mathf.Abs(Input.GetAxisRaw("RightHorizontal")) > 0.3f;
    }

    private bool CheckMove(out Vector3 moveDirection)
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(v) > 0.3f || Mathf.Abs(h) > 0.3f)
        {
            moveDirection = new Vector3(h, 0f, v);
            moveDirection.Normalize();
            return true;
        }
        moveDirection = Vector3.zero;
        return false;
    }
}
