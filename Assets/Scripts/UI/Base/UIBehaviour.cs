using UnityEngine;

public abstract class UIBehaviour : MonoBehaviour 
{
	private void Awake() { }

    public virtual void OnEnter() { }

    public virtual void OnUpdate() { }

    public virtual void OnExit() { }

    public virtual void OnPaused() { }

    public virtual void OnResumed() { }
}
