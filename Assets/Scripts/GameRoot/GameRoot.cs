using System;
using System.Collections;
using UnityEngine;

public class GameRoot : MonoBehaviour
{

    protected virtual void Awake() { }

    protected virtual IEnumerator _Release()
    {
        yield break;
    }

    public void LoadMainMenuScene()
    {
        LoadScene(CSceneManager.MainMenuScene);
    }

    public void LoadCurrentLevel()
    {
        LoadScene(CSceneManager.CurrentScene);
    }

    public void LoadNextLevel()
    {
        LoadScene(GameDataManager.GetNextLevelName());
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(_Release(), () => CSceneManager.LoadScene(sceneName));
    }

    public void QuitGame()
    {
        StartCoroutine(_Release(), () =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        });
    }

    public void StartCoroutine(IEnumerator iEnumerator, Action onComplete)
    {
        StartCoroutine(_Corotine(iEnumerator, onComplete));
    }

    private static IEnumerator _Corotine(IEnumerator iEnumerator, Action onComplete)
    {
        yield return iEnumerator;
        if (onComplete != null) onComplete();
    }
}
