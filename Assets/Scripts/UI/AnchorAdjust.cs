using UnityEngine;

public class AnchorAdjust : MonoBehaviour 
{
	private void Awake() { }

    private void Start()
    {
        GetComponent<RectTransform>().anchorMin = Vector2.one*0.5f;
        GetComponent<RectTransform>().anchorMax = Vector2.one*0.5f;
    }

    private void Update() { }
}
