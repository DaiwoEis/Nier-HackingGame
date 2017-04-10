using CUI;
using UnityEngine;

public class LevelUIController : MonoBehaviour
{
    [SerializeField]
    private BaseView _pausedView = null;

    [SerializeField]
    private BaseView _succeedView = null;

    [SerializeField]
    private BaseView _failuredView = null;

    [SerializeField]
    private BaseView _readyView = null;

    private void Awake()
    {
        GameStateController.instance.GetState(GameStateType.Succeed).onEnter += () =>
        {
             ViewController.instance.AddCommond(new OpenCommond(_succeedView));
        };

        GameStateController.instance.GetState(GameStateType.Failure).onEnter += () =>
        {
            ViewController.instance.AddCommond(new OpenCommond(_failuredView));
        };

        GameStateController.instance.GetState(GameStateType.Paused).onEnter += () =>
        {
            ViewController.instance.AddCommond(new OpenCommond(_pausedView));
        };

        ViewController.instance.AddCommond(new OpenCommond(_readyView));
        GameStateController.instance.GetState(GameStateType.Init).onEnter += () =>
        {
            ViewController.instance.AddCommond(new CloseCommond());
        };

    }
}
