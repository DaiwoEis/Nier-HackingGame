using CUI;
using UnityEngine;
using UnityEngine.UI;

public class RankListRoll : MonoBehaviour 
{
    [SerializeField]
    private ScrollRect _scrollRect = null;

    private RectTransform contentPanel;

    [SerializeField]
    private float _moveSpeed = 80f;

    private void Start()
    {
        contentPanel = _scrollRect.content;

        GetComponent<CWindow>().onUpdate += UpdateScrollRect;
    }

    private void UpdateScrollRect()
    {
        float contentMaxY = _scrollRect.content.anchoredPosition.y;
        float contentMinY = _scrollRect.content.anchoredPosition.y - _scrollRect.content.rect.height;

        float scrollViewMaxY = 0f;
        float scrollViewMinY = -_scrollRect.viewport.rect.height;

        if (contentMinY < scrollViewMinY)
        {
            if (Input.GetAxisRaw("Vertical") < 0f)
                contentPanel.anchoredPosition += Vector2.up*_moveSpeed*Time.deltaTime;
        }

        if (contentMaxY > scrollViewMaxY)
        {
            if (Input.GetAxisRaw("Vertical") > 0f)
                contentPanel.anchoredPosition += Vector2.down * _moveSpeed * Time.deltaTime;
        }
    }
}
