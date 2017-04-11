using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hitter : FunctionBehaviour
{
    [SerializeField]
    protected int _damage = 1;

    public int damage { get { return _damage; } }

    [SerializeField]
    private HitterLayer _hitterLayer = default(HitterLayer);

    public HitterLayer layer { get { return _hitterLayer; } }

    [SerializeField]
    private HitType _hitType = HitType.Weak;

    public HitType hitType { get { return _hitType; } }

    public event Action OnHit = null;

    private bool _hitObject = false;

    protected override void OnExecute()
    {
        base.OnExecute();

        _hitObject = false;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (_hitObject && OnHit != null)
        {
            OnHit();
            _hitObject = false;
        }            
    }

    protected virtual void onHit(HitableBehaviour hitTarget)
    {
        
    }

    protected override void onTriggerEnter(Collider other)
    {
        HitCheck(other);
    }

    private void HitCheck(Collider other)
    {
        var hitTarget = other.GetComponent<HitableBehaviour>();
        if (hitTarget != null && hitTarget.CanHit(this))
        {
            var hitResult = GetHitResult(other);
            hitTarget.Hit(this, hitResult);

            _hitObject = true;
            onHit(hitTarget);
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
}

public enum HitterLayer
{
    Player = 1 << 0,
    Enemy = 1 << 1,
    Environment = 1 << 2
}

public enum HitType
{
    Weak = 1 << 0,
    Strong = 1 << 1
}