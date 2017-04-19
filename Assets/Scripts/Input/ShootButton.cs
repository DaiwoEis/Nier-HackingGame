using UnityEngine;

public abstract class ShootButton : IButton
{
    public abstract bool Down();
    public abstract bool Up();
    public abstract bool Hold();
    public abstract void Update();
}

public class KeyboardShootButton : ShootButton
{
    public override bool Down()
    {
        return Input.GetButtonDown("Fire1");
    }

    public override bool Up()
    {
        return Input.GetButtonUp("Fire1");
    }

    public override bool Hold()
    {
        return Input.GetButton("Fire1");
    }

    public override void Update()
    {
        
    }
}

public class ControllerShootButton : ShootButton
{
    private float _lastFrameAxisData = 0f;

    private bool _buttonDown = false;

    private bool _buttonUp = false;

    private readonly float Press_Threshold = -0.1f;

    public override bool Down()
    {
        return _buttonDown;
    }

    public override bool Up()
    {
        return _buttonUp;
    }

    public override bool Hold()
    {
        return Input.GetAxisRaw("Triggers") < Press_Threshold;
    }

    public override void Update()
    {
        if (_buttonDown) _buttonDown = false;
        if (_buttonUp) _buttonUp = false;

        float currFrameAxisData = Input.GetAxisRaw("Triggers");
        if (currFrameAxisData < Press_Threshold && _lastFrameAxisData > Press_Threshold)
        {
            _buttonDown = true;
        }
        else if (currFrameAxisData > Press_Threshold && _lastFrameAxisData < Press_Threshold)
        {
            _buttonUp = true;
        }
        _lastFrameAxisData = currFrameAxisData;
    }
}

public class MobileShootButton : ShootButton
{
    private ScrollCircle _rightScrollCircle = null;

    public MobileShootButton()
    {
        _rightScrollCircle = GameObject.FindWithTag(TagConfig.RightMobileAxis).GetComponent<ScrollCircle>();
    }

    private bool _lastFrameIsDraging = false;

    private bool _buttonDown = false;

    private bool _buttonUp = false;

    public override bool Down()
    {
        return _buttonDown;
    }

    public override bool Up()
    {
        return _buttonUp;
    }

    public override bool Hold()
    {
        return _rightScrollCircle.draging;
    }

    public override void Update()
    {
        if (_buttonDown) _buttonDown = false;
        if (_buttonUp) _buttonUp = false;

        bool currFrameIsDraging = _rightScrollCircle.draging;
        if (_lastFrameIsDraging == false && currFrameIsDraging)
        {
            _buttonDown = true;
        }
        else if (_lastFrameIsDraging && currFrameIsDraging == false)
        {
            _buttonUp = true;
        }
        _lastFrameIsDraging = currFrameIsDraging;
    }
}