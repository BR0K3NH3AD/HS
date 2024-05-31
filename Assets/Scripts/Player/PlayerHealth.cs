using System.Collections;
using System.Collections.Generic;
using TDS.Scripts.Enemy;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.Scripts.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        private int _playerMaxHealth = 100;
        private int _currentPlayerHealth;
        private Slider playerHealthSlider;
        private PlayerUI playerUI;
        private int enemyDamage;

        public void Initialize(Slider playerHealthSlider, PlayerUI playerUI, int maxHealth)
        {
            this.playerHealthSlider = playerHealthSlider;
            this.playerUI = playerUI;
            _playerMaxHealth = maxHealth;
            _currentPlayerHealth = _playerMaxHealth;
            playerUI.SetMaxHealth(_playerMaxHealth);
        }

        public void TakeDamagePlayer(int damage)
        {
            _currentPlayerHealth -= damage;
            playerUI.SetHealth(_currentPlayerHealth);

            if (_currentPlayerHealth <= 0)
            {
                HandlePlayerDeath();
            }
        }

        private void HandlePlayerDeath()
        {
            Time.timeScale = 0f;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                BaseEnemy enemy = collision.collider.GetComponent<BaseEnemy>();
                if (enemy != null)
                {
                    enemyDamage = enemy.EnemyDamage;
                    TakeDamagePlayer(enemyDamage);
                }
            }
        }
    }
}