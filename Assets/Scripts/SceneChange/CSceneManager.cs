using UnityEngine.SceneManagement;

public class CSceneManager 
{
    public static readonly string IntermidiateScene = "Intermediate Scene";

    public static readonly string MainMenuScene = "Main Menu";

    public static string CurrentScene { get { return SceneManager.GetActiveScene().name; } }

    public static string NextScene = "";

    public static int GetSceneNumberByName(string sceneName)
    {
        return SceneManager.GetSceneByName(sceneName).buildIndex;
    }

    public static string GetSceneNameByNumber(int sceneNumber)
    {
        return SceneManager.GetSceneByBuildIndex(0).name;
    }

    public static void LoadScene(string nextScene)
    {
#if !PLATFORM_WEBGL
        NextScene = nextScene;
        SceneChangeEffect effect = Camera.main.GetComponent<SceneChangeEffect>();
        if (effect != null)
        {
            effect.Run(() => SceneManager.LoadScene(IntermidiateScene));
        }
        else
        {
            SceneManager.LoadScene(IntermidiateScene);
        }
#else
        SceneManager.LoadScene(nextScene);
#endif
    }
}
