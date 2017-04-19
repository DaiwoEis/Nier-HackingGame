using CUI;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{

#if MOBILE_PLATFORM
        [SerializeField]
        private BaseView _pausedView = null;
#endif

    private void Awake()
    {
#if MOBILE_PLATFORM
        _pausedView.onEnter += () => gameObject.SetActive(false);
        _pausedView.onExit += () => gameObject.SetActive(true);

        GetComponent<Button>().onClick.AddListener(() => GameStateController.instance.ChangeState(GameStateType.Paused));
#else
        gameObject.SetActive(false);
#endif
    }
}
