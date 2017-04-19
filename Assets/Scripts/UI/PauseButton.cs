using CUI;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{

    [SerializeField]
    private BaseView _pausedView = null;

    private void Awake()
    {
#if MOBILE_PLATFORM
        _pausedView.onEnter += () => gameObject.SetActive(false);
        _pausedView.onExit += () => gameObject.SetActive(true);

        GetComponent<Button>().onClick.AddListener(() =>
        {
            if (GameStateController.instance.currStateType == GameStateType.Running)
            {
                GameStateController.instance.ChangeState(GameStateType.Paused);
            }
        });
#else
        gameObject.SetActive(false);
#endif
    }
}
