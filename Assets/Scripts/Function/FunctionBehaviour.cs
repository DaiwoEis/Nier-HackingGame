using FullInspector;
using UnityEngine;

public class FunctionBehaviour : MonoBehaviour 
{
    [SerializeField]
    protected bool _running = false;

    public void Begin()
    {
        _running = true;
        OnBegin();
    }

    protected virtual void OnBegin() { }

    public void End()
    {
        _running = false;
        OnEnd();
    }

    protected virtual void OnEnd()
    {
        StopAllCoroutines();
    }

    [SerializeField]
    protected bool _pause = false;

    public bool pause
    {
        get { return _pause; }
        set
        {
            if (value && _pause == false)
                OnPause();
            else if (value == false && _pause)
                OnResume();
            _pause = value;
        }
    }

    public void Pause()
    {
        _pause = true;
        OnPause();
    }

    protected virtual void OnPause() { }

    public void Resume()
    {
        _pause = false;
        OnResume();
    }

    protected virtual void OnResume() { }

    protected void Update()
    {
        if (_pause || !_running) return;

        OnUpdate();
    }

    protected virtual void OnUpdate() { }

    protected void FixedUpdate()
    {
        if (_pause || !_running) return;

        OnFixedUpdate();
    }

    protected virtual void OnFixedUpdate() { }

    protected void LateUpdate()
    {
        if (_pause || !_running) return;

        OnLateUpdate();
    }

    protected virtual void OnLateUpdate() { }

    protected void OnTriggerEnter(Collider other)
    {
        if (_pause || !_running) return;

        WhenTriggerEnter(other);
    }

    protected virtual void WhenTriggerEnter(Collider other) { }

    protected void OnTriggerStay(Collider other)
    {
        if (_pause || !_running) return;

        WhenTriggerStay(other);
    }

    protected virtual void WhenTriggerStay(Collider other) { }

    protected void OnTriggerExit(Collider other)
    {
        if (_pause || !_running) return;

        WhenTriggerExit(other);
    }

    protected virtual void WhenTriggerExit(Collider other) { }

    protected void OnCollisionEnter(Collision other)
    {
        if (_pause || !_running) return;

        WhenCollisionEnter(other);
    }

    protected virtual void WhenCollisionEnter(Collision other) { }

    protected void OnCollisionStay(Collision other)
    {
        if (_pause || !_running) return;

        WhenCollisionStay(other);
    }

    protected virtual void WhenCollisionStay(Collision other) { }

    protected void OnCollisionExit(Collision other)
    {
        if (_pause || !_running) return;

        WhenCollisionExit(other);
    }

    protected virtual void WhenCollisionExit(Collision other) { }
}
