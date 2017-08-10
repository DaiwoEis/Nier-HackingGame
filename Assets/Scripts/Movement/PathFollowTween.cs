using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class PathFollowTween : FunctionBehaviour
{
    [SerializeField]
    private float _duration = 5f;

    [SerializeField]
    private List<Transform> _waypoints = null;

    private Tween _tween = null;

    protected override void OnBegin()
    {
        base.OnBegin();

        transform.position = new Vector3(_waypoints[0].position.x, _waypoints[0].position.y, _waypoints[0].position.z);
        _waypoints.Add(_waypoints[0]);
        _tween = transform.DOPath(_waypoints.Select(t => t.position).ToArray(), _duration, PathType.CatmullRom,
                PathMode.TopDown2D).
            SetLoops(-1).SetEase(Ease.Linear).SetOptions(AxisConstraint.Y);
    }

    protected override void OnPause()
    {
        base.OnPause();

        _tween.Pause();
    }

    protected override void OnResume()
    {
        base.OnResume();

        _tween.Play();
    }

    protected override void OnEnd()
    {
        base.OnEnd();

        _tween.Kill();
    }
}
