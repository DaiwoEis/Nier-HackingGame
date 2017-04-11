using CUI;
using UnityEngine;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField]
    private BaseView _mainMenuView = null;

    private void Start()
    { 
        Singleton<ViewController>.instance.AddCommond(new OpenCommond(_mainMenuView));
    }
}