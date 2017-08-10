using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CUI
{
    [RequireComponent(typeof(Animator))]
    public class CAnimateWindow : CWindow
    {
        protected Animator _animator;

        [SerializeField]
        private Dictionary<string, float> _stateLengthDic;

        public Dictionary<string, float> stateLengthDic
        {
            get { return _stateLengthDic; }
            set { _stateLengthDic = value; }
        }

        protected override void Awake()
        {
            base.Awake();

            gameObject.SetActive(true);
            _animator = GetComponent<Animator>();
            _animator.updateMode = AnimatorUpdateMode.UnscaledTime;                   
        }

        [ContextMenu("HideInEditor")]
        public void HideInEditor()
        {
            GetComponent<CanvasGroup>().alpha = 0f;
        }

        public override IEnumerator _Open()
        {
            yield return base._Open();

            _animator.Play(AnimatorStateConfig.State_Opening);
            yield return null;
            TriggerOnOpeningStartEvent();

            yield return new WaitForSecondsRealtime(_stateLengthDic[AnimatorStateConfig.State_Opening]);
            TriggerOnOpeningCompleteEvent();

            _animator.Play(AnimatorStateConfig.State_Opened);
            yield return null;
            TriggerOnOpenedEvent();
        }

        public override IEnumerator _Close()
        {
            yield return base._Close();

            _animator.Play(AnimatorStateConfig.State_Closing);
            yield return null;
            TriggerOnClosingStartEvent();

            yield return new WaitForSecondsRealtime(_stateLengthDic[AnimatorStateConfig.State_Closing]);

            TriggerOnClosingCompleteEvent();
            _animator.Play(AnimatorStateConfig.State_Closed);
            yield return null;
            TriggerOnClosedEvent();
        }

        public override IEnumerator _Pause()
        {
            yield return base._Pause();

            _animator.Play(AnimatorStateConfig.State_Pausing);
            yield return null;
            TriggerOnPausingStartEvent();

            yield return new WaitForSecondsRealtime(_stateLengthDic[AnimatorStateConfig.State_Pausing]);
            TriggerOnPausingCompleteEvent();

            _animator.Play(AnimatorStateConfig.State_Paused);
            yield return null;
            TriggerOnPausedEvent();
        }

        public override IEnumerator _Resume()
        {
            yield return base._Resume();

            _animator.Play(AnimatorStateConfig.State_Resuming);
            yield return null;
            TriggerOnResumingStartEvent();

            yield return new WaitForSecondsRealtime(_stateLengthDic[AnimatorStateConfig.State_Resuming]);
            TriggerOnResumingCompleteEvent();

            _animator.Play(AnimatorStateConfig.State_Opened);
            yield return null;
            TriggerOnOpenedEvent();
        }
    }
}
