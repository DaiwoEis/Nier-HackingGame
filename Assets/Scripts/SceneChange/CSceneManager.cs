using UnityEngine;
using UnityEngine.SceneManagement;

public class CSceneManager 
{
    public static readonly string IntermidiateScene = "Intermediate Scene";

    public static readonly string MainMenuScene = "Main Menu";

    public static string CurrentScene
    {
        get { return SceneManager.GetActiveScene().name; }
    }

    public static string NextScene = "";

    public static string GetNextSceneName(string sceneName)
    {
        string nextSceneName = "Level";
        int nextSceneNum = SceneManager.GetSceneByName(sceneName).buildIndex;
        nextSceneNum += 1;
        if (nextSceneNum > SceneManager.sceneCountInBuildSettings - 2)
            nextSceneNum = 0;
        if (nextSceneNum < 10)
            nextSceneName += " 0" + nextSceneNum;
        else
            nextSceneName += " " + nextSceneNum;
        Debug.Log(nextSceneNum+" "+nextSceneName);
        return nextSceneName;
    }

    public static void LoadScene(string nextScene)
    {
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
    }
}
