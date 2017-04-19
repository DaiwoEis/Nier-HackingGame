using System;
using UnityEngine;

public class KeyboardDevice : InputDevice 
{
    public override void TestChangeDevice(InputController inputController)
    {
        if (Input.GetKey(KeyCode.Joystick1Button0) ||
            Input.GetKey(KeyCode.Joystick1Button1) ||
            Input.GetKey(KeyCode.Joystick1Button2) ||
            Input.GetKey(KeyCode.Joystick1Button3) ||
            Input.GetKey(KeyCode.Joystick1Button4) ||
            Input.GetKey(KeyCode.Joystick1Button5) ||
            Input.GetKey(KeyCode.Joystick1Button6) ||
            Input.GetKey(KeyCode.Joystick1Button7) ||
            Input.GetKey(KeyCode.Joystick1Button8) ||
            Input.GetKey(KeyCode.Joystick1Button9) ||
            Input.GetKey(KeyCode.Joystick1Button10) ||
            Input.GetKey(KeyCode.Joystick1Button11) ||
            Input.GetKey(KeyCode.Joystick1Button12) ||
            Input.GetKey(KeyCode.Joystick1Button13) ||
            Input.GetKey(KeyCode.Joystick1Button14) ||
            Input.GetKey(KeyCode.Joystick1Button15) ||
            Input.GetKey(KeyCode.Joystick1Button16) ||
            Input.GetKey(KeyCode.Joystick1Button17) ||
            Input.GetKey(KeyCode.Joystick1Button18) ||
            Input.GetKey(KeyCode.Joystick1Button19) ||
            Math.Abs(Input.GetAxis("Horizontal")) > 0.00001f ||
            Math.Abs(Input.GetAxis("Vertical")) > 0.00001f ||
            Math.Abs(Input.GetAxis("Triggers")) > 0.00001f ||
            Math.Abs(Input.GetAxis("RightHorizontal")) > 0.00001f ||
            Math.Abs(Input.GetAxis("RightVertical")) > 0.00001f)
        {
            inputController.ChangeDevice<ControllerDevice>();
        }
    }
}

public class ControllerDevice : InputDevice
{
    public override void TestChangeDevice(InputController inputController)
    {
        if (Event.current.isKey || Event.current.isMouse || Math.Abs(Input.GetAxis("Mouse X")) > 0.00001f ||
            Math.Abs(Input.GetAxis("Mouse Y")) > 0.00001f)
        {
            inputController.ChangeDevice<KeyboardDevice>();
        }
    }
}

public class MobileDevice : InputDevice
{
    public override void TestChangeDevice(InputController inputController)
    {
        
    }
}