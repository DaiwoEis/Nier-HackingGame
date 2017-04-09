using System;
using UnityEngine;

[Serializable]
public class ForwardDirectionMoveToTarget : MoveToTarget
{
    [SerializeField]
    private float _rotationSpeed = 10f;

    protected override Vector3 GetVelocity(Vector3 targetPoint)
    {
        Vector3 toTarget = (targetPoint - _moveableObject.position).normalized;
        _moveableObject.forward = Vector3.Lerp(_moveableObject.forward, toTarget, _rotationSpeed*Time.deltaTime);
        float speed = (1f - Vector3.Angle(_moveableObject.forward, toTarget)/180f)*_maxSpeed;
        return _moveableObject.forward*speed;
    }
}
