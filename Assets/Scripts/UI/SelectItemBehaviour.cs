using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectItemBehaviour : UIBehaviour
{
    [SerializeField]
    private bool _isSelected = false;

    [SerializeField]
    private GameObject _firstSelectedGO = null;

    public override void OnEnter()
    {
        base.OnEnter();

#if !MOBILE_PLATFORM
        _isSelected = false;
        EventSystem.current.SetSelectedGameObject(gameObject);
#endif
    }

    public override void OnResumed()
    {
        base.OnResumed();

#if !MOBILE_PLATFORM
        _isSelected = false;
        EventSystem.current.SetSelectedGameObject(gameObject);
#endif
    }

    public override void OnPaused()
    {
        base.OnPaused();

#if !MOBILE_PLATFORM
        _isSelected = false;
        EventSystem.current.SetSelectedGameObject(gameObject);
#endif
    }

    public override void OnExit()
    {
        base.OnExit();

#if !MOBILE_PLATFORM
        _isSelected = false;
        EventSystem.current.SetSelectedGameObject(gameObject);
#endif
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

#if !MOBILE_PLATFORM
        if (_isSelected == false && Math.Abs(Input.GetAxisRaw("DpadY")) > 0.0001f)
        {
            EventSystem.current.SetSelectedGameObject(_firstSelectedGO);
            _isSelected = true;
        }
#endif
    }
}
