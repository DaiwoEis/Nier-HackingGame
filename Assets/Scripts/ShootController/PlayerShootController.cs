using UnityEngine;

public class PlayerShootController : FunctionBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab = null;

    [SerializeField]
    private Transform _shootPoint = null;

    [SerializeField]
    private float _shootInterval = 0.5f;

    [SerializeField]
    private AudioClip _shootSound = null;

    private AudioSource _audioSource = null;

    [SerializeField]
    private InputConroller _inputConroller = null;

    private float _timer = 0f;

    private void Awake()
    {
        _audioSource = _shootPoint.GetComponent<AudioSource>();
    }

    protected override void OnExecute()
    {
        base.OnExecute();

        _timer = _shootInterval;
    }

    protected override void OnUpdate()
    {
        if (_inputConroller.GetButtonHold<ShootButton>() && _timer >= _shootInterval)
        {
            Shoot();
            _timer = 0f;
        }

        _timer += Time.deltaTime;
    }

    private void Shoot()
    {
        if (_shootSound != null)
        {
            _audioSource.PlayOneShot(_shootSound);
        }
        Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
    }
}
