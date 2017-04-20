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

    protected void Hurt()
    {
        _isInvincible = true;

        if (onHurtEnter != null) onHurtEnter();
        _audioSource.PlayOneShot(_hurtClip);
        if (_spawnPrefabWhenHurt != null) Instantiate(_spawnPrefabWhenHurt, transform.position, transform.rotation);

        CoroutineUtility.UStartCoroutine(_hurtTime, () =>
        {
            _isInvincible = false;
            if (onHurtExit != null) onHurtExit();
        });
    }

    public void Death()
    {
        _isDead = true;

        if (onDeath != null) onDeath();

        WhenDeath();

        _audioSource.PlayOneShot(_deathClip);

        if (_spawnPrefabWhenDeath != null) Instantiate(_spawnPrefabWhenDeath, transform.position, transform.rotation);     
    }

    protected override void WhenSpawn()
    {
        base.WhenSpawn();

        _currHealthAmount = _maxHealthAmount;

        _isDead = false;

        ExecuteFunctions();

        if (GameStateController.instance.currStateType != GameStateType.Running)
        {
            PauseFunctions();
            GameStateController.instance.GetState(GameStateType.Running).onEnter += ResuneFunctions;
        }

        GameStateController.instance.GetState(GameStateType.Paused).onEnter += PauseFunctions;
        GameStateController.instance.GetState(GameStateType.Paused).onExit += ResuneFunctions;
    }


    protected virtual void WhenDeath()
    {
        EndFunctions();

        foreach (var meshRenderer in GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderer.enabled = false;
        }

        CoroutineUtility.UStartCoroutine(_dealthTime, Destroy);

        if (GameStateController.instance == null) return;

        GameStateController.instance.GetState(GameStateType.Paused).onEnter -= PauseFunctions;
        GameStateController.instance.GetState(GameStateType.Paused).onExit -= ResuneFunctions;
    }

    protected override void WhenDestory()
    {
        base.WhenDestory();

        EndFunctions();
    }
}
