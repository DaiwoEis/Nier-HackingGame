using System;
using CodingJar;
using UnityEngine;

public abstract class HitableBehaviour : FunctionBehaviour
{
    [SerializeField, EnumFlagsField]
    protected HitterLayer _canHitActorLayer = default(HitterLayer);

    public event Action onHitted = null;

    public virtual bool CanHit(Hitter hitter)
    {
        return _running && !_pause && LayerUtility.InLayerMask((int) hitter.layer, (int) _canHitActorLayer);
    }

    public virtual void Hit(Hitter hitter, HitResult hitResult)
    {
        if (onHitted != null) onHitted();
    }
}

public struct HitResult
{
    public Vector3 point;
    public Vector3 direction;
}