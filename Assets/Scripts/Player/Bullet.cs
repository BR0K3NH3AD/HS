using System.Collections;
using System.Collections.Generic;
using TDS.Scripts.Enemy;
using UnityEngine;

namespace TDS.Scripts
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float speed = 20f;
        [SerializeField] private int damage = 10;

        private Transform target;
        private Rigidbody2D rb;

        public void Seek(Transform _target)
        {
            target = _target;
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            if (target != null)
            {   
                Collider2D targetCollider = target.GetComponent<Collider2D>();
                Vector2 targetCenter = targetCollider.bounds.center;
                Vector2 direction = (targetCenter - (Vector2)transform.position).normalized;


                rb.velocity = direction * speed;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                BaseEnemy enemyHealth = collision.collider.GetComponent<BaseEnemy>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject); 
            }
        }
    }
}


