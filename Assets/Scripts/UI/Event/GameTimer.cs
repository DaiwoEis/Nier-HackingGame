using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private Text _timeText = null;

    private float _time = 0f;
    public float time { get { return _time; } }

    private bool _run = false;

    private void Awake()
    {
        _timeText = GetComponent<Text>();

        GameStateController.instance.onGameStart += () => _run = true;
        GameStateController.instance.onGamePaused += () => _run = false;
        GameStateController.instance.onGameResumed += () => _run = true;
        GameStateController.instance.onGameFailure += () => _run = false;
        GameStateController.instance.onGameSucced += () => _run = false;
    }

    private void Update()
    {
        if (_run)
        {
            _time += Time.deltaTime;
            DateTime dateTime = new DateTime();
            dateTime = dateTime.AddSeconds(_time);
            _timeText.text = NumberUtility.NormalizedNumber(dateTime.Minute) + ":" +
                             NumberUtility.NormalizedNumber(dateTime.Second);
        }
    }
}
