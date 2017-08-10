using CUI;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonSetup : MonoBehaviour
{
    [SerializeField]
    private CWindow _pausedWindow = null;

    private void Awake()
    {
#if Moblie_Platform
        GetComponent<Button>().onClick.AddListener(() =>
        {
            GameStateController.instance.ChangeState(GameStateType.Paused);
            gameObject.SetActive(false);
        });
        _pausedWindow.onClosingComplete += () => gameObject.SetActive(true);
#endif
    }

}
