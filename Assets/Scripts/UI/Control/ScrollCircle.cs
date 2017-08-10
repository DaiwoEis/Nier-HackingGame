using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollCircle : ScrollRect
{
    protected float _radius = 0f;

    public Vector2 axis { get { return content.anchoredPosition/_radius; } }

    public bool _draging = false;

    public bool draging { get { return _draging; } }

    protected override void Start()
    {
        base.Start();

        _radius = (transform as RectTransform).sizeDelta.x * 0.5f;
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        _draging = true;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        _draging = false;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        var contentPostion = content.anchoredPosition;
        if (contentPostion.magnitude > _radius)
        {
            contentPostion = contentPostion.normalized * _radius;
            SetContentAnchoredPosition(contentPostion);
        }
    }
}