using CUI;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReadyWindowSetup : MonoBehaviour , IPointerClickHandler
{
    private CWindow _readyWindow = null;

    private void Awake()
    {
        _readyWindow = GetComponent<CWindow>();
    }

    private bool TestPCAnyKeyDown()
    {
        return Event.current.isKey ||
               Input.GetKey(KeyCode.Joystick1Button0) ||
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
               Input.GetKey(KeyCode.Joystick1Button19);
    }

    private void OnGUI()
    {
#if !Moblie_Platform
        if (_readyWindow.type == CWindowStateType.Opened && TestPCAnyKeyDown())
            WindowController.instance.AddCommond(new CloseCommond());
#endif
    }

    public void OnPointerClick(PointerEventData eventData)
    {

#if Moblie_Platform
        WindowController.instance.AddCommond(new CloseCommond());
#endif
    }
}
