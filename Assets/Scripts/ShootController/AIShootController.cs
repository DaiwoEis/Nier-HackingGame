using UnityEngine;

public class AIShootController : FunctionBehaviour
{
    [SerializeField]
    private float _shootCoolDownTime = 1f;

    [SerializeField]
    private GameObject[] _bulletPrefabs = null;

    [SerializeField]
    private ShootMethod _shootMethod = default(ShootMethod);

    [SerializeField]
    private Transform _shootPoint = null;

    [SerializeField]
    private AudioClip _shootSound = null;

    [SerializeField]
    private AudioSource _audioSource = null;

    private int _sequenceIndex = 0;

    private bool _isCoolDown = false;

    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (_isCoolDown == false)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_shootPoint != null && !_audioSource.isPlaying) _audioSource.PlayOneShot(_shootSound);

        SpawnPrefab();

        _isCoolDown = true;
        this.StartCoroutine(_shootCoolDownTime, () => _isCoolDown = false);
    }

    private void SpawnPrefab()
    {
        GameObject bulletPrefab = null;

        switch (_shootMethod)
        {
            case ShootMethod.Sequence:
                bulletPrefab = _bulletPrefabs[_sequenceIndex];             
                _sequenceIndex = (_sequenceIndex + 1)%_bulletPrefabs.Length;
                break;

            case ShootMethod.Random:
                bulletPrefab = _bulletPrefabs[Random.Range(0, _bulletPrefabs.Length)];
                break;
        }

        ActorManager.instance.CreateObject(bulletPrefab, _shootPoint.position, _shootPoint.rotation);
    }
}

public enum ShootMethod
{
    Sequence,
    Random
}