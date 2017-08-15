using CUI;
using UnityEngine;
using UnityEngine.UI;

public class QuitGameButtonSetup : MonoBehaviour
{
    [SerializeField]
    private CWindow _ownerWindow = null;

    [SerializeField]
    private ConfirmWindowSetup _confirmWindowSetup = null;

    private Button _button = null;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() =>
        {
            _confirmWindowSetup.Setup(
                () => UIManager.instance.QuitGame(),
                () => WindowController.instance.AddCommond(new CloseCommond()),
                "Are you sure quit the game?");
            _ownerWindow.SetAnimationVersion(1);
            _ownerWindow.onOpened += ResetOwnerWindowAnimationVerson;
            WindowController.instance.AddCommond(new PauseCommond());
            WindowController.instance.AddCommond(new OpenCommond(_confirmWindowSetup.GetComponent<CWindow>()));
        });
    }

    private void ResetOwnerWindowAnimationVerson()
    {
        _ownerWindow.SetAnimationVersion(0);
        _ownerWindow.onOpened -= ResetOwnerWindowAnimationVerson;
    }
}
