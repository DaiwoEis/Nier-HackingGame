using System;
using CUI;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowSetup : MonoBehaviour
{
    private CWindow _window = null;

    [SerializeField]
    private AudioClip _windowOpenedSound = null;

    [SerializeField]
    private AudioClip _windowClosedSound = null;

    [SerializeField]
    private RectTransform _selectObjectHolder = null;

    [SerializeField]
    private GameObject _selectGameObject = null;

    [SerializeField]
    private bool _closeWindowWhenPressCancelButton = true;

    private void Awake()
    {
        _window = GetComponent<CWindow>();
        _window.onOpeningStart += () => { UIManager.instance.PlaySound(_windowOpenedSound); };
        _window.onClosingStart += () => { UIManager.instance.PlaySound(_windowClosedSound); };

        if (PlatformUtility.currentPlatform == PlatformType.PC)
        {
            PCSetUp();
        }
    }

    private void Start()
    {
        if (_selectObjectHolder != null)
            _selectGameObject = _selectObjectHolder.GetChild(0).gameObject;
    }

    private void PCSetUp()
    {
        _window.onUpdate += UpdateSelection;
        _window.onOpened += () => { EventSystem.current.SetSelectedGameObject(_selectGameObject); };

        if (_closeWindowWhenPressCancelButton)
            _window.onUpdate += CheckWindowClose;
    }

    private void CheckWindowClose()
    {
        if (Input.GetButtonDown("Cancel"))
            WindowController.instance.AddCommond(new CloseCommond());
    }

    private void UpdateSelection()
    {
        if (EventSystem.current.currentSelectedGameObject != null) return;

        float v = Input.GetAxisRaw("Vertical");
        if (Math.Abs(v) > 0.3f)
            EventSystem.current.SetSelectedGameObject(_selectGameObject);
    }
}
