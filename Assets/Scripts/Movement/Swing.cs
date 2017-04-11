using UnityEngine;

public class Swing : FunctionBehaviour
{
    [SerializeField]
    private float _maxAngle = 90f;

    [SerializeField]
    private float _rotationSpeed = 30f;

    [SerializeField]
    private float _compeleteTime;

    [SerializeField]
    private float _timer = 0f;

    private Quaternion _originRotation = Quaternion.identity;

    private void Awake()
    {
        _compeleteTime = _maxAngle/_rotationSpeed*2f;
    }

    private void Start()
    {
        _originRotation = transform.rotation;
    }

    protected override void OnExecute()
    {
        base.OnExecute();

        _timer = 0f;
    }

    protected override void OnUpdate()
    {
        _timer += Time.deltaTime;
        float angle = Mathf.Lerp(-_maxAngle, _maxAngle, Mathf.PingPong(_timer, _compeleteTime) / _compeleteTime);
        transform.rotation = _originRotation*Quaternion.Euler(0f, angle, 0f);
    }
}
