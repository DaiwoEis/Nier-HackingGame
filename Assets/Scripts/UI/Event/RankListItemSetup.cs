using CUI;
using UnityEngine;

public class RankListItemSetup : MonoBehaviour
{
    [SerializeField]
    private GameObject _itemPrefab = null;

    [SerializeField]
    private RectTransform _context = null;

    private CWindow _rankListMenu = null;

    private RankListItem[] _rankListItems = null;

    private void Awake()
    {
        _rankListMenu = GetComponent<CWindow>();
        _rankListItems = new RankListItem[GameDataManager.gameData.gameLevelCount];
        for (int i = 0; i < _rankListItems.Length; ++i)
        {
            _rankListItems[i] =
               Instantiate(_itemPrefab, Vector3.zero, Quaternion.identity, _context).GetComponent<RankListItem>();
        }
        _rankListMenu.onOpeningStart += ShowList;
    }

    private void ShowList()
    {
        for (int i = 0; i < _rankListItems.Length; i++)
            _rankListItems[i].Show(GameDataManager.levelDatas[i]);
    }
}
