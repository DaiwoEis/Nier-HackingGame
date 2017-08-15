using System;
using UnityEngine;

public class PawnHealth : HitableBehaviour
{
    [SerializeField]
    protected int _maxHealthAmount = 100;
    public int maxHealthAmount { get { return _maxHealthAmount; } }

    [SerializeField]
    protected int _currHealthAmount = 0;
    public int currHealthAmount { get { return _currHealthAmount; } set { _currHealthAmount = value; } }

    [SerializeField]
    private float _hurtTime = 0f;

    [SerializeField]
    protected AudioClip _hurtClip = null;

    [SerializeField]
    private GameObject _spawnPrefabWhenHurt = null;

    [SerializeField]
    private float _dealthTime = 0.1f;
    public float dealthTime { get { return _dealthTime; } }

    [SerializeField]
    protected AudioClip _deathClip = null;

    [SerializeField]
    private GameObject _spawnPrefabWhenDeath = null;

    private bool _isDead = false;
    public bool isDead { get { return _isDead; } }

    private bool _isInvincible = false;
    public bool isInvincible { get { return _isInvincible; } }

    protected AudioSource _audioSource = null;

    public event Action onDeath;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();        
    }

    protected override void OnBegin()
    {
        base.OnBegin();

        _currHealthAmount = _maxHealthAmount;
        _isDead = false;
        _isInvincible = false;
    }

    protected override void OnEnd()
    {
        base.OnEnd();

        onDeath = null;
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

        _audioSource.PlayOneShot(_hurtClip);
        if (_spawnPrefabWhenHurt != null)
            ActorManager.instance.CreateObject(_spawnPrefabWhenHurt, transform.position, transform.rotation);

        this.StartCoroutine(_hurtTime, () => _isInvincible = false);
    }

    public void Death()
    {
        _isDead = true;
     
        if (onDeath != null) onDeath();

        foreach (var meshRenderer in GetComponentsInChildren<MeshRenderer>())
            meshRenderer.enabled = false;

        if (GameStateController.instance == null) return;

        _audioSource.PlayOneShot(_deathClip);

        if (_spawnPrefabWhenDeath != null) Instantiate(_spawnPrefabWhenDeath, transform.position, transform.rotation);     
    }

    public override void Hit(Hitter hitter, HitResult hitResult)
    {
        TakeDamage(hitter, hitResult);

        base.Hit(hitter, hitResult);
    }
}
