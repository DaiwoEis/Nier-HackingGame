﻿using UnityEngine;

public class AIShootController : FunctionBehaviour
{
    private float _shootIntetval = 1f;

    [SerializeField]
    private GameObject[] _bulletPrefabs = null;

    [SerializeField]
    private ShootMethod _shootMethod = default(ShootMethod);

    [SerializeField]
    private Transform _shootPoint = null;

    [SerializeField]
    private AudioClip _shootSound = null;

    private AudioSource _audioSource = null;

    private int _sequenceIndex = 0;

    private float _timer = 0f;

    public enum ShootMethod
    {
        Sequence,
        Random
    }

    public bool running { get; set; }

    private void Awake()
    {
        _audioSource = _shootPoint.GetComponent<AudioSource>();
    }

    protected override void OnExecute()
    {
        _timer = _shootIntetval;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        _timer += Time.deltaTime;
        if (_timer >= _shootIntetval)
        {
            SpawnPrefab();
            if (_shootPoint != null) _audioSource.PlayOneShot(_shootSound);
            _timer = 0f;
        }
    }

    private void SpawnPrefab()
    {
        switch (_shootMethod)
        {
            case ShootMethod.Sequence:
                Instantiate(_bulletPrefabs[_sequenceIndex], _shootPoint.position,
                    _shootPoint.rotation);
                _sequenceIndex = (_sequenceIndex + 1)%_bulletPrefabs.Length;
                break;
            case ShootMethod.Random:
                Instantiate(_bulletPrefabs[Random.Range(0, _bulletPrefabs.Length)],
                    _shootPoint.position,
                    _shootPoint.rotation);
                break;
        }
    }
}
