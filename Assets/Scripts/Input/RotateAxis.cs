﻿using UnityEngine;

public abstract class RotateAxis : IAxis 
{
    public abstract Vector3 Axis();
    public abstract void Update();
}

public class KeyboardRotateAxis : RotateAxis
{
    private Transform _player = null;

    public KeyboardRotateAxis()
    {
        _player = GameObject.FindWithTag(TagConfig.Player).transform;
    }

    public override Vector3 Axis()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo,
            1 << LayerMask.NameToLayer("Ground")))
        {
            return PlaneUtility.Direction(hitInfo.point - _player.position);
        }

        return Vector3.zero;
    }

    public override void Update()
    {
        
    }
}

public class ControllerRotateAxis : RotateAxis
{
    public override Vector3 Axis()
    {
        Vector3 axis = new Vector3(Input.GetAxisRaw("RightHorizontal"), 0f, Input.GetAxisRaw("RightVertical"));
        return axis != Vector3.zero ? axis.normalized : Vector3.zero;
    }

    public override void Update()
    {
        
    }
}

public class MobileRotateAxis : RotateAxis
{
    private ScrollCircle _scrollCircle = null;

    public MobileRotateAxis()
    {
        _scrollCircle = GameObject.FindWithTag(TagConfig.RightMobileAxis).GetComponent<ScrollCircle>();
    }

    public override Vector3 Axis()
    {
        return new Vector3(_scrollCircle.axis.x, 0f, _scrollCircle.axis.y);
    }

    public override void Update()
    {

    }
}