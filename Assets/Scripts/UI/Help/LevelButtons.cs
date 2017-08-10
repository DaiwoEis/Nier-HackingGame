using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    [SerializeField]
    private GameObject _buttonPrefab = null;

    [SerializeField]
    private RectTransform _content = null;

    private void Awake()
    {
        GameData gameData = (GameData)Resources.Load("GameData/Data", typeof(GameData));
        for (int i = 1; i <= gameData.gameLevelCount; ++i)
        {
            GameObject button = Instantiate(_buttonPrefab, Vector3.zero, Quaternion.identity, _content);
            string levelName = "Level ";
            if (i < 10)
                levelName += "0" + i;
            else
                levelName += i;
            button.GetComponentInChildren<Text>().text = levelName;
            button.GetComponent<Button>().onClick.AddListener(() => UIManager.instance.LoadScene(levelName));
        }
    }
}
