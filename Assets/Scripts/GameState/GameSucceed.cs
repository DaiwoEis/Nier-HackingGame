using CUI;
using UnityEngine;

public class GameSucceed : GameState
{
    [SerializeField]
    private CWindow _succeedWindow = null;

    [SerializeField]
    private GameTimer _gameTimer = null;

    private PawnHealth _playerHealth = null;

#if UNITY_EDITOR
    [SerializeField]
    private string _succeedWindowName = "SucceedWindow";

    [SerializeField]
    private string _gameTimerName = "GameTimer";

    public override void Setup()
    {
        base.Setup();

        _succeedWindow = GameObject.Find(_succeedWindowName).GetComponent<CWindow>();
        _gameTimer = GameObject.Find(_gameTimerName).GetComponent<GameTimer>();
    }
#endif

    public override void Init(GameStateController controller)
    {
        base.Init(controller);

        _stateType = GameStateType.Succeed;
        _playerHealth = GameObject.Find(TagConfig.Player).GetComponent<PawnHealth>();
    }

    public override void OnEnter(GameState lastState)
    {
        base.OnEnter(lastState);

        WindowController.instance.AddCommond(new OpenCommond(_succeedWindow));

        var levelData = GameDataManager.GetLevelData(GameDataManager.currentLevel);
        if (levelData.complete == false)
        {
            levelData.complete = true;
            levelData.consumeTime = _gameTimer.time;
            levelData.consumeLife = _playerHealth.maxHealthAmount - _playerHealth.currHealthAmount;
        }
        else
        {
            if (_gameTimer.time < levelData.consumeTime)
            {
                levelData.consumeTime = _gameTimer.time;
                if (_playerHealth.maxHealthAmount - _playerHealth.currHealthAmount > levelData.consumeLife)
                    levelData.consumeLife = _playerHealth.maxHealthAmount - _playerHealth.currHealthAmount;
            }
        }
    }
}