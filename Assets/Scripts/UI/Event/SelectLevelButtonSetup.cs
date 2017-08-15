using UnityEngine;
using UnityEngine.UI;

public class SelectLevelButtonSetup : MonoBehaviour
{
    [SerializeField]
    private GameObject _buttonPrefab = null;

    [SerializeField]
    private RectTransform _content = null;

    private void Awake()
    {
        GameData gameData = GameDataManager.gameData;
        for (int i = 1; i <= gameData.gameLevelCount; ++i)
        {
            GameObject button = Instantiate(_buttonPrefab, Vector3.zero, Quaternion.identity, _content);
            string levelName = GameDataManager.GetLevelName(i);
            button.GetComponentInChildren<Text>().text = levelName;
            button.GetComponent<Button>().onClick.AddListener(() => UIManager.instance.LoadScene(levelName));
        }
    }
}
