using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField]
    private int _currentHP = 5;
    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private Transform _enemyPos;


   //make private if performance problems!!!
    public void DamageEnemy(int _damage)
    {
        _currentHP -= _damage;

        if(_currentHP <= 0)
        {
            Instantiate(_explosion, _enemyPos.position, _enemyPos.rotation);
            Destroy(gameObject);
        }
    }
}
