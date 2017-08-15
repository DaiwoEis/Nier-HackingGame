using System;
using UnityEngine;
using UnityEngine.UI;

public class RankListItem : MonoBehaviour
{
    [SerializeField]
    private Text _levelNameText = null;

    [SerializeField]
    private Text _consumeTimeText = null;

    [SerializeField]
    private Text _consumeLifeText = null;

    private static string Default_Time = "--:--";
    private static string Default_Life = "-";

    public void Show(LevelData levelData)
    {
        if (levelData.complete)
        {
            _levelNameText.text = levelData.name;
            _consumeLifeText.text = levelData.consumeLife.ToString();
            var dateTime = new DateTime();
            dateTime = dateTime.AddSeconds(levelData.consumeTime);
            _consumeTimeText.text = NumberUtility.NormalizedNumber(dateTime.Minute) + ":" +
                                    NumberUtility.NormalizedNumber(dateTime.Second);
        }
        else
        {
            _levelNameText.text = levelData.name;
            _consumeTimeText.text = Default_Time;
            _consumeLifeText.text = Default_Life;
        }
    }
}
