using UnityEngine;

public class PlayerShootController : FunctionBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab = null;

    [SerializeField]
    private Transform _shootPoint = null;

    [SerializeField]
    private float _shootCoolDownTime = 0.5f;

    [SerializeField]
    private AudioClip _shootSound = null;

    private AudioSource _audioSource = null;

    private bool _isCoolDown = false;

    public void Awake()
    {
        _audioSource = _shootPoint.GetComponent<AudioSource>();
    }

    protected override void OnBegin()
    {
        base.OnBegin();

        _isCoolDown = false;
    }

    protected override void OnUpdate()
    {
        if (InputController.instance.GetButtonHold<ShootButton>() && _isCoolDown == false)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (_shootSound != null)
            _audioSource.PlayOneShot(_shootSound);

        ActorManager.instance.CreateObject(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);

        _isCoolDown = true;
        this.StartCoroutine(_shootCoolDownTime, () => _isCoolDown = false);
    }
}
