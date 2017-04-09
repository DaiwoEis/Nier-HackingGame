using System.Collections;
using UnityEngine;

public class AIShootController : FunctionBehaviour
{
    private float _shootIntetval = 1f;

    [SerializeField]
    private GameObject[] _bulletPrefabs = null;

    [SerializeField]
    private ShootMethod _shootMethod = default(ShootMethod);

    [SerializeField]
    private Transform _shootPoint = null;

    private int _sequenceIndex = 0;

    private Coroutine _shootCoroutine = null;

    public enum ShootMethod
    {
        Sequence,
        Random
    }

    public bool running { get; set; }

    protected override void OnExecute()
    {
        _shootCoroutine = StartCoroutine(_Shoot());
    }

    private IEnumerator _Shoot()
    {
        while (true)
        {
            if (!_running || _pause) continue;

            SpawnPrefab();

            yield return new WaitForSeconds(_shootIntetval);
        }
        // ReSharper disable once IteratorNeverReturns
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

    protected override void OnEnd()
    {
        StopCoroutine(_shootCoroutine);
    }
}
