using UnityEngine;

public class FaceToTarget : FunctionBehaviour
{
    [SerializeField]
    private Transform _target = null;

    protected override void OnUpdate()
    {
        base.OnUpdate();

        transform.forward = PlaneUtility.Direction(_target.position - transform.position);
    }
}
