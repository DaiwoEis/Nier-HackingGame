using CUI;
using UnityEngine;

public class PauseButtonSetup : MonoBehaviour
{
    [SerializeField]
    private CWindow _pausedWindow = null;

    private void Awake()
    {
#if Moblie_Platform
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
        {
            GameStateController.instance.ChangeState(GameStateType.Paused);
            gameObject.SetActive(false);
        });
        _pausedWindow.onClosingComplete += () => gameObject.SetActive(true);
#endif
    }

}
