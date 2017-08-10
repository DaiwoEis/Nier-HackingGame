using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : FunctionBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;

    [SerializeField]
    private float _rotationSpeed = 20f;

    private Rigidbody _rigidbody = null;

    private InputController _inputController = null;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _inputController = InputController.instance;
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

    protected override void OnUpdate()
    {
        Vector3 moveDirection;
        if (CheckMove(out moveDirection))
        {            
            Vector3 rotateDirection;
            if (CheckRotate())
            {
                rotateDirection = _inputController.GetAxis<RotateAxis>();          
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
                Vector3 rotateDirection = _inputController.GetAxis<RotateAxis>();
                transform.forward = Vector3.Lerp(transform.forward, rotateDirection, _rotationSpeed*Time.deltaTime);
            }
            _rigidbody.velocity = Vector3.zero;
        }
    }

    private bool CheckRotate()
    {
        return _inputController.GetAxis<RotateAxis>() != Vector3.zero;
    }

    private bool CheckMove(out Vector3 moveDirection)
    {
        Vector3 localInput = _inputController.GetAxis<MoveAxis>();           
        if (Mathf.Abs(localInput.x) > 0.1f || Mathf.Abs(localInput.z) > 0.1f)
        {
            moveDirection = localInput;
            moveDirection.Normalize();
            return true;
        }
        moveDirection = Vector3.zero;
        return false;
    }
}
