using System;
using System.Collections;
using UnityEngine;

namespace CUI
{
	public abstract class BaseView : MonoBehaviour
	{
#if DEBUG_UI
        private int n;    
#endif

        [SerializeField]
	    protected float _openTime = 0.5f;

        [SerializeField]
	    protected float _closeTime = 0.5f;

        [SerializeField]
	    protected float _resumeTime = 0.5f;

        [SerializeField]
	    protected float _pauseTime = 0.5f;

	    public event Action onEnter = null;
	    public event Action onExit = null;
	    public event Action onPaused = null;
	    public event Action onResumed = null;

        [SerializeField]        
	    protected UIBehaviour[] _uiBehaviours = null;

	    protected virtual void Awake()
	    {
            _uiBehaviours = GetComponentsInChildren<UIBehaviour>();
        }

        protected virtual void Start() { }

	    protected void Update() { }

	    public virtual void OnUpdate()
	    {
#if DEBUG_UI
            if (n < 5)
	        {
	            Debug.Log(string.Format("{0} Update", uiType.Name));
	            n++;
	        }    
#endif

            foreach (var uiBehaviour in _uiBehaviours)
	        {
	            uiBehaviour.OnUpdate();
	        }
	    }

	    public virtual IEnumerator _OnEnter()
	    {
            gameObject.SetActive(true);
	        if (onEnter != null) onEnter();
            foreach (var uiBehaviour in _uiBehaviours)
            {
                uiBehaviour.OnEnter();
            }

#if DEBUG_UI
            n = 0;
            Debug.Log(string.Format("{0} Enter", gameObject.name));
#endif

	        yield return new WaitForSecondsRealtime(_openTime);
	    }

        public virtual IEnumerator _OnPause()
        {            
#if DEBUG_UI
            n = 0;
            Debug.Log(string.Format("{0} Pause", gameObject.name));
#endif

            yield return new WaitForSecondsRealtime(_pauseTime);
            if (onPaused != null) onPaused();
            foreach (var uiBehaviour in _uiBehaviours)
            {
                uiBehaviour.OnPaused();
            }
            gameObject.SetActive(false);
        }

        public virtual IEnumerator _OnResume()
	    {
            gameObject.SetActive(true);

#if DEBUG_UI
            Debug.Log(string.Format("{0} Resume", gameObject.name));
#endif

            yield return new WaitForSecondsRealtime(_resumeTime);

	        if (onResumed != null) onResumed();
            foreach (var uiBehaviour in _uiBehaviours)
            {
                uiBehaviour.OnResumed();
            }           
	    }

        public virtual IEnumerator _OnExit()
	    {
#if DEBUG_UI
            Debug.Log(string.Format("{0} Exit", gameObject.name));
#endif

            yield return new WaitForSecondsRealtime(_closeTime);

	        if (onExit != null) onExit();
            foreach (var uiBehaviour in _uiBehaviours)
            {
                uiBehaviour.OnExit();
            }
            gameObject.SetActive(false);
        }
	}
}
