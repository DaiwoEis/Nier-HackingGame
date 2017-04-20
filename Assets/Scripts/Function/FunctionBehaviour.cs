using UnityEngine;

public class FunctionBehaviour : MonoBehaviour 
{
    [SerializeField]
    protected bool _running = false;

    public void Execute()
    {
        _running = true;
        OnExecute();
    }

    protected virtual void OnExecute() { }

    public void End()
    {
        _running = false;
        OnEnd();
    }

    protected virtual void OnEnd() { }

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

        onTriggerEnter(other);
    }

    protected virtual void onTriggerEnter(Collider other) { }

    protected void OnTriggerStay(Collider other)
    {
        if (_pause || !_running) return;

        onTriggerStay(other);
    }

    protected virtual void onTriggerStay(Collider other) { }

    protected void OnTriggerExit(Collider other)
    {
        if (_pause || !_running) return;

        onTriggerExit(other);
    }

    protected virtual void onTriggerExit(Collider other) { }

    protected void OnCollisionEnter(Collision other)
    {
        if (_pause || !_running) return;

        onCollisionEnter(other);
    }

    protected virtual void onCollisionEnter(Collision other) { }

    protected void OnCollisionStay(Collision other)
    {
        if (_pause || !_running) return;

        onCollisionStay(other);
    }

    protected virtual void onCollisionStay(Collision other) { }

    protected void OnCollisionExit(Collision other)
    {
        if (_pause || !_running) return;

        onCollisionExit(other);
    }

    protected virtual void onCollisionExit(Collision other) { }
}
