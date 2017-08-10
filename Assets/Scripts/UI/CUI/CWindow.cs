using System;
using System.Collections;
using FullInspector;
using UnityEngine;

namespace CUI
{
    public abstract class CWindow : BaseBehavior
    {

#if DEBUG_UI
        private int n;    
#endif

        public event Action onOpeningStart = null;
        public event Action onOpeningComplete = null;

        public event Action onClosingStart = null;
        public event Action onClosingComplete = null;

        public event Action onPausingStart = null;
        public event Action onPausingComplete = null;

        public event Action onResumingStart = null;
        public event Action onResumingComplete = null;

        protected void TriggerOnOpeningStartEvent()
        {
            if (onOpeningStart != null) onOpeningStart();
        }

        protected void TriggerOnOpeningCompleteEvent()
        {
            if (onOpeningComplete != null) onOpeningComplete();
        }

        protected void TriggerOnClosingStartEvent()
        {
            if (onClosingStart != null) onClosingStart();
        }

        protected void TriggerOnClosingCompleteEvent()
        {
            if (onClosingComplete != null) onClosingComplete();
        }

        protected void TriggerOnPausingStartEvent()
        {
            if (onPausingStart != null) onPausingStart();
        }

        protected void TriggerOnPausingCompleteEvent()
        {
            if (onPausingComplete != null) onPausingComplete();
        }

        protected void TriggerOnResumingStartEvent()
        {
            if (onResumingStart != null) onResumingStart();
        }

        protected void TriggerOnResumingCompleteEvent()
        {
            if (onResumingComplete != null) onResumingComplete();
        }

        public event Action onOpened = null;
        public event Action onClosed = null;
        public event Action onPaused = null;

        protected void TriggerOnOpenedEvent()
        {
            if (onOpened != null) onOpened();
        }

        protected void TriggerOnClosedEvent()
        {
            if (onClosed != null) onClosed();
        }

        protected void TriggerOnPausedEvent()
        {
            if (onPaused != null) onPaused();
        }

        public event Action onUpdate = null;

        public CWindowStateType type { get; protected set; }

        protected virtual void Start()
        {
            onOpened += () => { type = CWindowStateType.Opened; };
            onClosed += () => { type = CWindowStateType.Closed; };
            onPaused += () => { type = CWindowStateType.Paused; };
        }

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

            if (onUpdate != null) onUpdate();
        }

        public virtual IEnumerator _Open()
        {

#if DEBUG_UI
            n = 0;
            Debug.Log(string.Format("{0} Enter", gameObject.name));
#endif

            yield break;
        }

        public virtual IEnumerator _Pause()
        {

#if DEBUG_UI
            n = 0;
            Debug.Log(string.Format("{0} Pause", gameObject.name));
#endif

            yield break;
        }

        public virtual IEnumerator _Resume()
        {

#if DEBUG_UI
            Debug.Log(string.Format("{0} Resume", gameObject.name));
#endif

            yield break;
        }

        public virtual IEnumerator _Close()
        {

#if DEBUG_UI
            Debug.Log(string.Format("{0} Exit", gameObject.name));
#endif

            yield break;
        }
    }

    public enum CWindowStateType
    {
        Opened,
        Closed,
        Paused
    }
}
