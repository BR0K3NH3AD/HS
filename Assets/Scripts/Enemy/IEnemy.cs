using UnityEngine;

namespace TDS.Scripts.Enemy
{
    public interface IEnemy
    {
        void TakeDamage(int damage);
        void Move();
        void Die();
        void Instialize(Transform player, EnemySettings settings);
    }

}
