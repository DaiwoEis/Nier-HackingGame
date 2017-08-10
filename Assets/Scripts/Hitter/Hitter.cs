using System;
using UnityEngine;

public class Hitter : FunctionBehaviour
{
    [SerializeField]
    protected int _damage = 1;
    public int damage { get { return _damage; } }

    [SerializeField]
    private HitterLayer _hitterLayer = default(HitterLayer);
    
    public HitterLayer layer { get { return _hitterLayer; } }

    public event Action onHit = null;

    protected void HitCheck(Collider other)
    {
        var hitTarget = other.GetComponent<HitableBehaviour>();
        if (hitTarget != null && hitTarget.CanHit(this))
        {
            var hitResult = GetHitResult(other);
            hitTarget.Hit(this, hitResult);

            if (onHit != null) onHit();
            //Debug.Log(gameObject.name + " hit " + other.gameObject.name);
        }
    }

    private HitResult GetHitResult(Collider other)
    {
        HitResult hitResult;
        hitResult.point = other.ClosestPointOnBounds(transform.position);
        hitResult.direction = hitResult.point - transform.position;
        if (hitResult.direction != Vector3.zero)
        {
            hitResult.direction.y = 0f;
            hitResult.direction.Normalize();
        }
        else
        {
            hitResult.direction = transform.forward;
        }
        return hitResult;
    }

    protected override void OnEnd()
    {
        base.OnEnd();

        onHit = null;
    }
}

public enum HitterLayer
{
    PlayerBullet = 1 << 0,
    EnemyOrangeBullet = 1 << 1,
    EnemyPurpleBullet = 1 << 2,
    ShockWave = 1 << 3
}