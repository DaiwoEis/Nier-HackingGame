using CUI;
using UnityEngine;

public class MainMenuRoot : GameRoot 
{
    [SerializeField]
    private CWindow _mainMenuWindow = null;

    protected override void Awake()
    {
        base.Awake();

        WindowController.instance.transform.parent = transform;
        WindowController.instance.AddCommond(new OpenCommond(_mainMenuWindow));
    }    
}
