using UnityEngine;

public class Rotate : FunctionBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 10f;

	private void Awake() { }

    private void Start() { }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        transform.Rotate(Vector3.up, _rotationSpeed*Time.deltaTime);
    }
}
