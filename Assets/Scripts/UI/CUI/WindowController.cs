using System.Collections;
using System.Collections.Generic;
using CUI;
using UnityEngine;

public abstract class UICommond
{
    public abstract IEnumerator Execute(Stack<CWindow> windowStack);
}

public class OpenCommond : UICommond
{
    private CWindow _nextWindow = null;

    public OpenCommond(CWindow nextWindow)
    {
        _nextWindow = nextWindow;
    }

    public override IEnumerator Execute(Stack<CWindow> windowStack)
    {
        if (_nextWindow == null)
        {
            Debug.LogWarning("Next window is null");
            yield break;
        }

        windowStack.Push(_nextWindow);
        yield return WindowController.instance.StartCoroutine(_nextWindow._Open());
    }
}

public class CloseCommond : UICommond
{

    public override IEnumerator Execute(Stack<CWindow> windowStack)
    {
        if (windowStack.Count != 0)
        {
            CWindow curView = windowStack.Peek();
            yield return WindowController.instance.StartCoroutine(curView._Close());
            windowStack.Pop();
        }

        if (windowStack.Count != 0)
        {
            CWindow lastView = windowStack.Peek();
            yield return WindowController.instance.StartCoroutine(lastView._Resume());
        }
    }
}

public class PauseCommond : UICommond
{
    public override IEnumerator Execute(Stack<CWindow> windowStack)
    {
        if (windowStack.Count != 0)
        {
            CWindow curView = windowStack.Peek();
            yield return WindowController.instance.StartCoroutine(curView._Pause());
        }
    }
}

public class CloseAllCommond : UICommond
{
    public override IEnumerator Execute(Stack<CWindow> windowStack)
    {
        if (windowStack.Count != 0)
        {
            CWindow curView = windowStack.Peek();
            yield return WindowController.instance.StartCoroutine(curView._Close());
            windowStack.Pop();
        }
        windowStack.Clear();
    }
}

public class WindowController : MonoSingleton<WindowController>
{
    private Stack<CWindow> _windowStack = null;

    private Queue<UICommond> _uiCommonds = null;

    private Coroutine _checkCommondCoroutine = null;

    public CWindow currWindow
    {
        get
        {
            if (_windowStack.Count != 0)
                return _windowStack.Peek();
            return null;
        }
    }

    protected override void OnCreate()
    {
        base.OnCreate();

        _windowStack = new Stack<CWindow>();
        _uiCommonds = new Queue<UICommond>();
        _checkCommondCoroutine = StartCoroutine(_CheckCommond());
    }

    protected override void OnRelease()
    {
        base.OnRelease();

        if (_checkCommondCoroutine != null)
            StopCoroutine(_checkCommondCoroutine);
    }

    public void AddCommond(UICommond commond)
    {
        _uiCommonds.Enqueue(commond);
    }

    public CWindow GetCurrentView()
    {
        return _windowStack.Count != 0 ? _windowStack.Peek() : null;
    }

    private IEnumerator _CheckCommond()
    {
        while (true)
        {
            if (_uiCommonds.Count > 0)
            {
                UICommond commond = _uiCommonds.Dequeue();
                yield return StartCoroutine(commond.Execute(_windowStack));
            }
            else
            {
                UpdateWindow();
                yield return null;
            }
        }
        // ReSharper disable once IteratorNeverReturns
    }

    private void UpdateWindow()
    {
        if (_windowStack.Count != 0)
        {
            _windowStack.Peek().OnUpdate();
        }
    }
}