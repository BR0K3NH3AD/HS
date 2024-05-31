using System.Collections;
using System.Collections.Generic;
using TDS.Scripts.Player;
using UnityEngine;


namespace TDS.Scripts.Enemy
{
    public class BaseEnemy : MonoBehaviour, IEnemy
    {
        protected float _enemySpeed;
        protected int _enemyHealth;
        protected int _enemyDamage;

        public int EnemyDamage => _enemyDamage;

        protected Transform player;
        protected Animator animator;
        protected bool isDead = false;
        protected SpriteRenderer spriteRenderer;
        public virtual void Instialize(Transform player, EnemySettings settings)
        {
            this.player = player;
            _enemySpeed = settings.Speed;
            _enemyHealth = settings.Health;
            _enemyDamage = settings.Damage;
        }

        protected virtual void Start()
        {
            animator = GetComponent<Animator>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            EnemyManager enemyManager = FindObjectOfType<EnemyManager>();
            if (enemyManager != null)
            {
                enemyManager.RegisterEnemy(this);
            }
        }

        protected virtual void FixedUpdate()
        {
            if (!isDead)
            {
                Move();
            }
        }
        public virtual void Move()
        {
            if (player != null)
            {
                Vector2 direction = (player.position - transform.position).normalized;
                transform.Translate(direction * _enemySpeed * Time.deltaTime);

                if (direction.x > 0)
                {
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
                else if (direction.x < 0)
                {
                    transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
            }
        }
        public virtual void TakeDamage(int damage)
        {
            _enemyHealth -= damage;
            if(_enemyHealth <= 0)
            {
                Die();
            }
        }

        public virtual void Die()
        {
            isDead = true;
            animator.SetBool("isDie", true);
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 1f);

            EnemyManager enemyManager= FindObjectOfType<EnemyManager>();
            if(enemyManager != null)
            {
                enemyManager.UnregisterEnemy(this);
            }
        }
        
        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamagePlayer(_enemyDamage);
                }
            }
        }
    }
}
