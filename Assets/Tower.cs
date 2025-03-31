using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{

    [SerializeField]
    private int _power = 0;

    [SerializeField]
    private float _powerReciveSpeed = 2.0f;

    [SerializeField]
    private Text _powerLabel;

    [SerializeField]
    private Color _selectedTowerColor;

    [SerializeField]
    private Color _unSelectedTowerColor;

    [SerializeField]
    private Button _selectTowerButton;

    [SerializeField]
    private Bullet _bulletPrefab;

    public UnityAction onSelectTower;

    private float _currentRecivePowerValue = 0.0f;
    private bool _isSelectedTower = false;
    private bool _isShoting = false;

    public void SetSelectValue(bool value) {
        _isSelectedTower = value;
    }

    void Start()
    {
        UpdatePowerLabel();
        UpdateSelectColor();
        if (_selectTowerButton) {
            _selectTowerButton.onClick.AddListener(onSelectTower);
        }
    }

    void Update()
    {
        if (_isShoting) {
            return;
        }
        _currentRecivePowerValue += Time.deltaTime;
        if (_currentRecivePowerValue > _powerReciveSpeed) {
            _power++;
            _currentRecivePowerValue -= _powerReciveSpeed;
            UpdatePowerLabel();
        }
    }

    public void UpdatePowerLabel() {
        if (_powerLabel) {
            _powerLabel.text = _power.ToString();
        }
    }

    public void UpdateSelectColor()
    {
        if (_selectTowerButton)
        {
            _selectTowerButton.image.color = _isSelectedTower ? _selectedTowerColor : _unSelectedTowerColor;
        }
    }

    public void Shot(Tower enemy) {
        StartCoroutine(SpawnBullet(enemy));

    }

    public IEnumerator SpawnBullet(Tower enemy) {

        _isShoting = true;
        while (_power > 0) {
            var bullet = Instantiate(_bulletPrefab, gameObject.transform);
            bullet.Init(enemy);
            _power--;
            UpdatePowerLabel();
            yield return new WaitForSeconds(0.5f);
        }
        _isShoting = false;
        yield return null;
    }

    public void Damage() {
        _power--;
    }
}
