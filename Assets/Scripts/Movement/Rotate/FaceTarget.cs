using System;
using UnityEngine;

public class FaceTarget : FunctionBehaviour
{
    [SerializeField]
    private Transform _target = null;

    [SerializeField]
    private float _rotateSpeed = -1f;

    protected override void OnUpdate()
    {
        base.OnUpdate();

        Vector3 direction = PlaneUtility.Direction(_target.position - transform.position);
        if (Math.Abs(_rotateSpeed + 1f) < 0.1f)
        {
            FaceToDirection(direction);
        }
        else
        {
            RotateToDirection(direction);
        }
    }

    private void FaceToDirection(Vector3 direction)
    {
        transform.forward = direction;
    }

    private void RotateToDirection(Vector3 direction)
    {
        transform.forward = Vector3.Lerp(transform.forward, direction, _rotateSpeed*Time.deltaTime);
    }
}
