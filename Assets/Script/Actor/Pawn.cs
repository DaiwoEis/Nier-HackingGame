using System;
using UnityEngine;

public class Pawn : Actor
{
    [SerializeField]
    protected int _maxHealthAmount = 100;

    [SerializeField]
    protected int _currHealthAmount = 0;

    public int currHealthAmount { get { return _currHealthAmount; } }

    [SerializeField]
    private float _hurtTime = 0f;

    [SerializeField]
    private float _dealthTime = 0f;

    private bool _isDead = false;

    public bool isDead { get { return _isDead; } }

    private bool _isInvincible = false;

    public bool isInvincible { get { return _isInvincible; } }

    public event Action onHurt;

    public event Action onHurtExit;

    public event Action onDeath;

    protected void TriggerOnHurtEvent()
    {
        if (onHurt != null) onHurt();
    }

    protected void TriggerOnHurtExitEvent()
    {
        if (onHurtExit != null) onHurtExit();
    }

    protected void TriggerOnDeathEvent()
    {
        if (onDeath != null) onDeath();
    }

    public void TakeDamage(Hitter hitter, HitResult hitResult)
    {
        if (_isDead || _isInvincible) return;        

        _currHealthAmount = (int)Mathf.Max(0f, _currHealthAmount - hitter.damage);

        if (_currHealthAmount > 0)
        {
            Hurt();
        }
        else
        {
            Death();
        }
    }

    public override void Spawn()
    {
        TriggerOnSpawnEvent();

        _currHealthAmount = _maxHealthAmount;
        _isDead = false;
    }

    protected virtual void Hurt()
    {
        TriggerOnHurtEvent();

        _isInvincible = true;
        CoroutineUtility.UStartCoroutine(_hurtTime, () =>
        {
            _isInvincible = false;
            if (onHurtExit != null) onHurtExit();
        });
    }

    public virtual void Death()
    {
        TriggerOnDeathEvent();

        _isDead = true;

        CoroutineUtility.UStartCoroutine(_dealthTime, Destroy);       
    }

    public override void Destroy()
    {
        TriggerOnDestroyEvent();

        Destroy(gameObject);
    }
}
