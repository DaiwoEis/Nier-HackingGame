using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSetup : MonoBehaviour , ISelectHandler
{
    [SerializeField]
    private AudioClip _buttonClickSound = null;

    [SerializeField]
    private AudioClip _buttonSelectSound = null;

    private void Awake()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(() => UIManager.instance.PlaySound(_buttonClickSound));
        button.onClick.AddListener(() => EventSystem.current.SetSelectedGameObject(null));
    }

    public void OnSelect(BaseEventData eventData)
    {
        if (PlatformUtility.currentPlatform == PlatformType.PC)
            UIManager.instance.PlaySound(_buttonSelectSound);
    }
}
