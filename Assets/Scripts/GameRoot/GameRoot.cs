//using UnityEditor;

using UnityEditor;
using UnityEngine;

public class GameRoot : MonoBehaviour
{
    protected virtual void Awake()
    {
        WindowController.Create();
        UIManager.Create();

        WindowController.instance.transform.parent = transform;
    }

    protected virtual void ClearGameController()
    {
        UIManager.Release();
        WindowController.Release();
    }

    public void LoadMainMenuScene()
    {
        LoadScene(CSceneManager.MainMenuScene);
    }

    public void LoadCurrentScene()
    {
        LoadScene(CSceneManager.CurrentScene);
    }

    public void LoadNextScene()
    {
        LoadScene(CSceneManager.GetNextSceneName(CSceneManager.CurrentScene));
    }

    public void LoadScene(string sceneName)
    {
        WindowController.instance.AddCommond(new CloseAllCommond());

        this.StartCoroutine(0.6f, () =>
        {
            ClearGameController();
            CSceneManager.LoadScene(sceneName);
        });
    }

    public void QuitGame()
    {
        WindowController.instance.AddCommond(new CloseAllCommond());

        this.StartCoroutine(0.6f, () =>
        {
            ClearGameController();
            Application.Quit();
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
                    Application.Quit();
#endif
        });
    }
}
