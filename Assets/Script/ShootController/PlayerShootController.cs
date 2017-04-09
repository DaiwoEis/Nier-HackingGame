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
    private AudioSource _audioSource = null;

    private float _timer = 0f;

    protected override void OnExecute()
    {
        base.OnExecute();

        _timer = _shootInterval;
    }

    protected override void OnUpdate()
    {
        if (Input.GetAxisRaw("Triggers") < -0.01f && _timer >= _shootInterval)
        {
            Shoot();
            _timer = 0f;
        }

        _timer += Time.deltaTime;
    }

    private void Shoot()
    {
        if (_audioSource != null) _audioSource.Play();
        Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
    }
}
