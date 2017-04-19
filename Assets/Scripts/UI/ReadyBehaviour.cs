using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReadyBehaviour : UIBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Text _readyText = null;

	private void Awake() { }

    public override void OnUpdate()
    {
        base.OnUpdate();

        string buttonText;

#if MOBILE_PLATFORM
        buttonText = "Any key";
#else
        buttonText = InputController.instance.currDevice.GetType() == typeof(KeyboardDevice) ? "ESC" : "B";
#endif

        StringBuilder builder = new StringBuilder();
        builder.Append("Press ");
        builder.Append(buttonText);
        builder.Append(" to");
        _readyText.text = builder.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
#if MOBILE_PLATFORM
       Singleton<ViewController>.instance.AddCommond(new CloseCommond());;
#endif        
    }
}
