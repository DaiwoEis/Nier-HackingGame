using UnityEngine;
using UnityEngine.UI;

public class UISizeAdjust : MonoBehaviour
{
    [SerializeField]
    private bool _adjustWidth = false;

    [SerializeField]
    private RectTransform _widthRectTransform = null;

    [SerializeField]
    private float _minWidth = 0f;

    [SerializeField]
    private float _maxWidth = 0f;

    [SerializeField]
    private bool _adjustHeight= false;

    [SerializeField]
    private RectTransform _heightRectTransform = null;

    [SerializeField]
    private float _minHeight = 0f;

    [SerializeField]
    private float _maxHeight = 0f;

    private RectTransform _rectTransform = null;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (_adjustWidth)
        {
            float newWidth = _widthRectTransform.sizeDelta.x;
            newWidth = Mathf.Clamp(newWidth, _minWidth, _maxWidth);
            _rectTransform.sizeDelta = new Vector2(newWidth, _rectTransform.sizeDelta.y);
        }

        if (_adjustHeight)
        {
            float newHeight = _heightRectTransform.sizeDelta.y;
            newHeight = Mathf.Clamp(newHeight, _minHeight, _maxHeight);
            _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, newHeight);
        }
    }
}
