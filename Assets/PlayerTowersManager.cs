using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTowersManager : MonoBehaviour
{
    [SerializeField]
    private List<Tower> _playerTowers = new List<Tower>(3);

    [SerializeField]
    private List<Tower> _enemyTowers = new List<Tower>(3);

    private Tower _selectedTower;
    void Start()
    {
        foreach(var tower in _playerTowers){
            tower.onSelectTower += () => {
                if (_selectedTower) {
                    _selectedTower.SetSelectValue(false);
                    _selectedTower.UpdateSelectColor();
                }
                _selectedTower = tower;
                _selectedTower.SetSelectValue(true);
                _selectedTower.UpdateSelectColor();
            };
        }

        foreach (var enemy in _enemyTowers)
        {
            enemy.onSelectTower += () => {
                if (_selectedTower)
                {
                    _selectedTower.Shot(enemy);
                }
            };
        }
    }

}
