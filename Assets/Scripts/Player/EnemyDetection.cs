using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.Scripts.Player
{
    public class EnemyDetection : MonoBehaviour
    {
        private float attackRadius;
        private LayerMask enemyLayer;
        private List<Transform> enemiesInRange = new List<Transform>();

        public void Initialize(float attackRadius, LayerMask enemyLayer)
        {
            this.attackRadius = attackRadius;
            this.enemyLayer = enemyLayer;
        }

        private void Update()
        {
            DetectEnemies();
        }

        private void DetectEnemies()
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRadius, enemyLayer);
            enemiesInRange.Clear();
            foreach (Collider2D collider in hitEnemies)
            {
                enemiesInRange.Add(collider.transform);
            }
        }

        public Transform GetNearestEnemy()
        {
            Transform nearestEnemy = null;
            float shortestDistance = Mathf.Infinity;

            foreach (Transform enemy in enemiesInRange)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, enemy.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            return nearestEnemy;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRadius);
        }
    }
}
