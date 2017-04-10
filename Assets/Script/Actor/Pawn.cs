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
    private float _dealthTime = 0.1f;

    private bool _isDead = false;

    public bool isDead { get { return _isDead; } }

    private bool _isInvincible = false;

    [SerializeField]
    protected AudioClip _hurtClip = null;

    [SerializeField]
    private GameObject _spawnPrefabWhenHurt = null;

    [SerializeField]
    protected AudioClip _deathClip = null;

    [SerializeField]
    private GameObject _spawnPrefabWhenDeath = null;

    protected AudioSource _audioSource = null;

    public bool isInvincible { get { return _isInvincible; } }

    public event Action onHurtEnter;

    public event Action onHurtExit;

    public event Action onDeath;

    protected override void Awake()
    {
        base.Awake();

        _audioSource = GetComponent<AudioSource>();
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

    protected void Hurt()
    {
        _isInvincible = true;

        OnHurtEnter();
        if (onHurtEnter != null) onHurtEnter();
        _audioSource.PlayOneShot(_hurtClip);
        if (_spawnPrefabWhenHurt != null) Instantiate(_spawnPrefabWhenHurt, transform.position, transform.rotation);

        CoroutineUtility.UStartCoroutine(_hurtTime, () =>
        {
            _isInvincible = false;
            OnHurtExit();
            if (onHurtExit != null) onHurtExit();
        });
    }

    protected virtual void OnHurtEnter()
    {
        
    }

    protected virtual void OnHurtExit()
    {
        
    }

    public virtual void Death()
    {
        TriggerOnDeathEvent();

        _isDead = true;

        _audioSource.PlayOneShot(_deathClip);

        if (_spawnPrefabWhenDeath != null) Instantiate(_spawnPrefabWhenDeath, transform.position, transform.rotation);

        CoroutineUtility.UStartCoroutine(_dealthTime, Destroy);       
    }

    public override void Destroy()
    {
        _worked = false;

        TriggerOnDestroyEvent();

        Destroy(gameObject);
    }
}
