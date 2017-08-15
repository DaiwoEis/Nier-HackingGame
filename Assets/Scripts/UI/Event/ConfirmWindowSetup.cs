using System;
using CUI;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmWindowSetup : MonoBehaviour
{

    [SerializeField]
    private Button _yesButton = null;

    [SerializeField]
    private Button _noButton = null;

    [SerializeField]
    private Text _content = null;

    private CWindow _confirmWindow = null;

    private void Awake()
    {
        _confirmWindow = GetComponent<CWindow>();
        _confirmWindow.onClosed += ClearData;
    }

    public void Setup(Action yesAction, Action noAction, string content)
    {
        _yesButton.onClick.AddListener(() =>
        {
            if (yesAction != null) yesAction();
        });
        _noButton.onClick.AddListener(() =>
        {
            if (noAction != null) noAction();
        });
        _content.text = content;
    }

    public void ClearData()
    {
        _yesButton.onClick.RemoveAllListeners();
        _noButton.onClick.RemoveAllListeners();
        _content.text = "";
    }
}
