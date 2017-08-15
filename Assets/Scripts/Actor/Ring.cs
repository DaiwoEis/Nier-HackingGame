using DG.Tweening;
using UnityEngine;

public class Ring : Actor
{
    private Renderer _renderer = null;

    [SerializeField]
    private float _fromScale = 0.35f;

    [SerializeField]
    private float _toScale = 0.35f;

    [SerializeField]
    private float _showTime = 0.1f;

    protected override void Awake()
    {
        base.Awake();

        _renderer = GetComponentInChildren<Renderer>();
        _renderer.enabled = false;
    }

    public override void OnSpawn()
    {
        base.OnSpawn();

        _renderer.enabled = true;
        transform.localScale = Vector3.one * _fromScale;
        transform.DOScale(Vector3.one*_toScale, _showTime).onComplete += () => { _renderer.enabled = false; };
    }
}
