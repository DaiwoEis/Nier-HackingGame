using System;
using UnityEngine;

public class NoHealthBody : HitableBehaviour
{
    [SerializeField]
    private GameObject _spawnObjectWhenHit = null;

    [SerializeField]
    private AudioClip _hittedSound = null;

    private AudioSource _audioSource = null;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public override void Hit(Hitter hitter, HitResult hitResult)
    {
        if (_hittedSound != null)
        {
            _audioSource.clip = _hittedSound;
            _audioSource.Play();
        }

        if (_spawnObjectWhenHit != null)
        {
            Instantiate(_spawnObjectWhenHit, hitResult.point, Quaternion.LookRotation(-hitResult.direction));
        }
    }
}
