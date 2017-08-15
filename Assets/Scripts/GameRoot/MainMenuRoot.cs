using System.Collections;
using CUI;
using UnityEngine;

public class MainMenuRoot : GameRoot 
{
    [SerializeField]
    private CWindow _mainMenuWindow = null;

    protected override void Awake()
    {
        base.Awake();

        WindowController.Create();
        UIManager.Create();

        WindowController.instance.Run();
        WindowController.instance.transform.parent = transform;
        WindowController.instance.AddCommond(new OpenCommond(_mainMenuWindow));
    }

    protected override IEnumerator _Release()
    {
        yield return WindowController._Release();
        yield return UIManager._Release();
        yield return base._Release();
    }
}
