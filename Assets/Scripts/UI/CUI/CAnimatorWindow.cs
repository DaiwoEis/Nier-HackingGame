using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CUI
{
    [RequireComponent(typeof(Animator))]
    public class CAnimatorWindow : CWindow
    {
        protected Animator _animator;

        [SerializeField]
        private Dictionary<string, float>[] _stateLengthDics = null;
        public Dictionary<string, float>[] stateLengthDics
        {
            get { return _stateLengthDics; }
            set { _stateLengthDics = value; }
        }

        public override void SetAnimationVersion(int newVersion)
        {
            int stateHash = _animator.GetCurrentAnimatorStateInfo(_animationVerson).shortNameHash;
            for (int i = 0; i < _stateLengthDics.Length; ++i)
                _animator.SetLayerWeight(i, i == newVersion ? 1f : 0f);
            _animator.Play(stateHash, newVersion);
            _animationVerson = newVersion;
        }

        protected override void Awake()
        {
            base.Awake();

            gameObject.SetActive(true);
            _animator = GetComponent<Animator>();
            _animator.updateMode = AnimatorUpdateMode.UnscaledTime;
            _animationVerson = 0;
        }

        [ContextMenu("HideInEditor")]
        public void HideInEditor()
        {
            GetComponent<CanvasGroup>().alpha = 0f;
        }

        public override IEnumerator _Open()
        {
            yield return base._Open();

            _animator.Play(AnimatorStateConfig.State_Opening, animationVersion);
            yield return null;
            TriggerOnOpeningStartEvent();

            yield return new WaitForSecondsRealtime(_stateLengthDics[animationVersion][AnimatorStateConfig.State_Opening]);
            TriggerOnOpeningCompleteEvent();

            _animator.Play(AnimatorStateConfig.State_Opened, animationVersion);
            yield return null;
            TriggerOnOpenedEvent();
        }

        public override IEnumerator _Close()
        {
            yield return base._Close();

            _animator.Play(AnimatorStateConfig.State_Closing, animationVersion);
            yield return null;
            TriggerOnClosingStartEvent();

            yield return new WaitForSecondsRealtime(_stateLengthDics[animationVersion][AnimatorStateConfig.State_Closing]);

            TriggerOnClosingCompleteEvent();
            _animator.Play(AnimatorStateConfig.State_Closed, animationVersion);
            yield return null;
            TriggerOnClosedEvent();
        }

        public override IEnumerator _Pause()
        {
            yield return base._Pause();

            _animator.Play(AnimatorStateConfig.State_Pausing, animationVersion);
            yield return null;
            TriggerOnPausingStartEvent();

            yield return new WaitForSecondsRealtime(_stateLengthDics[animationVersion][AnimatorStateConfig.State_Pausing]);
            TriggerOnPausingCompleteEvent();

            _animator.Play(AnimatorStateConfig.State_Paused, animationVersion);
            yield return null;
            TriggerOnPausedEvent();
        }

        public override IEnumerator _Resume()
        {
            yield return base._Resume();

            _animator.Play(AnimatorStateConfig.State_Resuming, animationVersion);
            yield return null;
            TriggerOnResumingStartEvent();

            yield return new WaitForSecondsRealtime(_stateLengthDics[animationVersion][AnimatorStateConfig.State_Resuming]);
            TriggerOnResumingCompleteEvent();

            _animator.Play(AnimatorStateConfig.State_Opened, animationVersion);
            yield return null;
            TriggerOnOpenedEvent();
        }
    }
}
