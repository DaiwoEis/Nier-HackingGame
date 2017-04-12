using UnityEngine;

public abstract class MoveToTarget
{
    [SerializeField]
    protected float _maxSpeed = 10f;

    [SerializeField]
    protected float _stopDistance = 1f;

    protected Transform _moveableObject = null;

    public void Init(Transform moveableObject)
    {
        _moveableObject = moveableObject;
    }

    public Vector3 Run(Vector3 targetPoint)
    {
        if (PlaneUtility.Distance(targetPoint, _moveableObject.position) > _stopDistance*_stopDistance)
        {
            return GetVelocity(targetPoint);
        }

        return Vector3.zero;
    }

    protected abstract Vector3 GetVelocity(Vector3 targetPoint);
}