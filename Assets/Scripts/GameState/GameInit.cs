using System.Collections;
using UnityEngine;

public class GameInit : GameState
{
    [SerializeField]
    private GameObject _blackScreenPanel = null;

    public override void Init()
    {
        base.Init();

        _stateType = GameStateType.Init;
    }

    public override void OnEnter()
    {
        base.OnEnter();

        StartCoroutine(_Init());
    }

    private IEnumerator _Init()
    {
        _blackScreenPanel.SetActive(true);
        yield return new WaitForEndOfFrame();
        _blackScreenPanel.SetActive(false);
        SceneChangeEffect effect=Camera.main.GetComponent<SceneChangeEffect>();
        if (effect != null)
        {
            effect.RunReverse(() => _stateController.ChangeState(GameStateType.Ready));
        }
        else
        {
            _stateController.ChangeState(GameStateType.Ready);
        }            
    }
}