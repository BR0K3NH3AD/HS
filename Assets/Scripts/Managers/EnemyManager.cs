using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TDS.Scripts.Enemy
{
    public class EnemyManager : MonoBehaviour
    {
        private List<IEnemy> _enemies = new List<IEnemy>();
    
        public void RegisterEnemy(IEnemy enemy)
        {
            if (!_enemies.Contains(enemy)) _enemies.Add(enemy);
        }

        public void UnregisterEnemy(IEnemy enemy)
        {
            if (_enemies.Contains(enemy)) _enemies.Remove(enemy);
        }

        public void DamageAllEnemies (int damage)
        {
            foreach(var enemy in _enemies)
            {
                enemy.TakeDamage(damage);
            }
        }

        public void MoveAllEnemies()
        {
            foreach(var enemy in _enemies)
            {
                enemy.Move();
            }
        }

        public void KillAllEnemies()
        {
            foreach(var enemy in _enemies)
            {
                enemy.Die();
            }
        }
    }
}
