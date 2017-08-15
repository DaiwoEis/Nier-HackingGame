using UnityEngine;
using UnityEngine.UI;

public class BossHealthPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _healthBoxPrefab = null;

    [SerializeField]
    private PawnHealth _bossHealth = null;

    private Image[] _boxImages = null;

    private void Awake()
    {
        if (_bossHealth == null)
            _bossHealth = GameObject.FindWithTag(TagConfig.Boss).GetComponent<PawnHealth>();
        _bossHealth.onHitted += UpdateHealth;
        _boxImages = new Image[_bossHealth.maxHealthAmount];
        for (int i = 0; i < _bossHealth.maxHealthAmount; i++)
            _boxImages[i] = Instantiate(_healthBoxPrefab, transform).GetComponent<Image>();
    }

    private void UpdateHealth()
    {
        for (int i = 0; i < _bossHealth.currHealthAmount; ++i)
            _boxImages[i].enabled = true;

        for (int i = _bossHealth.currHealthAmount; i < _bossHealth.maxHealthAmount; ++i)
            _boxImages[i].enabled = false;
    }
}
