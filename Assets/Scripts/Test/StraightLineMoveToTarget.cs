using System;
using UnityEngine;

[Serializable]
public class StraightLineMoveToTarget : MoveToTarget
{
    protected override Vector3 GetVelocity(Vector3 targetPoint)
    {
        Vector3 toTarget = (targetPoint - _moveableObject.position).normalized;
        return toTarget*_maxSpeed;
    }
}
