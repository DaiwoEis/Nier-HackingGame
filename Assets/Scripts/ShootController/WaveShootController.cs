using System;
using System.Collections;
using UnityEngine;

public class WaveShootController : FunctionBehaviour
{
    [SerializeField]
    private ShootMethod _shootMethod = ShootMethod.Sequence;

    [SerializeField]
    private SequenceWave _sequenceWave = null;

    [SerializeField]
    private RandomWave _randomWave = null;

    [SerializeField]
    private float _shootCoolDownTime = 1f;

    [SerializeField]
    private Transform _shootPoint = null;

    [SerializeField]
    private AudioClip _shootSound = null;

    [SerializeField]
    private AudioSource _audioSource = null;

    [SerializeField]
    private bool _isCoolDown = false;

    private Func<IEnumerator> _shootFunc = null;

    private void Awake()
    {
        if (_shootMethod == ShootMethod.Sequence)
            _shootFunc = _SequenceShoot;
        else
            _shootFunc = _RandomShoot;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        if (_isCoolDown == false)
        {
            StartCoroutine(_shootFunc());
        }
    }

    private IEnumerator _RandomShoot()
    {
        _isCoolDown = true;

        for (int i = 0; i < _randomWave.waveLength - 1; ++i)
        {
            if (_pause) yield return StartCoroutine(_CheckResume());

            SpawnBullet(_randomWave.bulletPrefab[UnityEngine.Random.Range(0, _randomWave.bulletPrefab.Length)]);
            yield return new WaitForSeconds(_randomWave.shootIntervial);
        }
        SpawnBullet(_randomWave.bulletPrefab[UnityEngine.Random.Range(0, _randomWave.bulletPrefab.Length)]);
        yield return new WaitForSeconds(_shootCoolDownTime);

        _isCoolDown = false;
    }

    private IEnumerator _SequenceShoot()
    {
        _isCoolDown = true;

        for (int i = 0; i < _sequenceWave.bulletPrefab.Length - 1; ++i)
        {
            if (_pause) yield return StartCoroutine(_CheckResume());

            SpawnBullet(_sequenceWave.bulletPrefab[i]);
            yield return new WaitForSeconds(_sequenceWave.shootIntervial);
        }
        SpawnBullet(_sequenceWave.bulletPrefab[_sequenceWave.bulletPrefab.Length - 1]);
        yield return new WaitForSeconds(_shootCoolDownTime);

        _isCoolDown = false;
    }

    private IEnumerator _CheckResume()
    {
        while (true)
        {
            if (!pause)
                break;
            yield return null;
        }
    }

    private void SpawnBullet(GameObject prefab)
    {
        ActorManager.instance.CreateObject(prefab, _shootPoint.position, _shootPoint.rotation);
        _audioSource.PlayOneShot(_shootSound);
    }
}
