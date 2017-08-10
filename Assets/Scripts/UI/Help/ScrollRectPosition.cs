using CUI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollRectPosition : MonoBehaviour
{
    [SerializeField]
    private ScrollRect _scrollRect = null;

    private RectTransform contentPanel;

    [SerializeField]
    private float _moveTime = 0.1f;

    private float _viewPortHeight;

    private void Start()
    {
        contentPanel = _scrollRect.content;
        _viewPortHeight = _scrollRect.viewport.rect.height;

        GetComponent<CWindow>().onUpdate += UpdateScrollRect;
    }

    private void UpdateScrollRect()
    {
        GameObject selected = EventSystem.current.currentSelectedGameObject;

        if (selected == null) return;
        if (selected.transform.parent != contentPanel.transform) return;

        RectTransform selectedRectTransform1 = selected.GetComponent<RectTransform>();

        float selectedPosMaxY = selectedRectTransform1.anchoredPosition.y + contentPanel.anchoredPosition.y;
        float selectedPosMinY = selectedRectTransform1.anchoredPosition.y + contentPanel.anchoredPosition.y -
                                selectedRectTransform1.rect.height;

        float scrollViewMaxY = 0f;
        float scrollViewMinY = -_viewPortHeight;

        if (selectedPosMinY < scrollViewMinY)
        {
            float newY = contentPanel.anchoredPosition.y + selectedRectTransform1.rect.height/_moveTime*Time.deltaTime;
            newY = Mathf.Clamp(newY, contentPanel.anchoredPosition.y,
                contentPanel.anchoredPosition.y + selectedRectTransform1.rect.height);
            contentPanel.anchoredPosition = new Vector2(contentPanel.anchoredPosition.x, newY);
        }
        else if (selectedPosMaxY > scrollViewMaxY)
        {
            float newY = contentPanel.anchoredPosition.y - selectedRectTransform1.rect.height/_moveTime*Time.deltaTime;
            newY = Mathf.Clamp(newY, contentPanel.anchoredPosition.y - selectedRectTransform1.rect.height,
                contentPanel.anchoredPosition.y);
            contentPanel.anchoredPosition = new Vector2(contentPanel.anchoredPosition.x, newY);
        }
    }
}