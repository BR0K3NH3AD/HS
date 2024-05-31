using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TDS.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.Scripts.Player
{
    public class PlayerManager : MonoBehaviour
    {

        /// <summary>
        /// Getting links to player components
        /// </summary>
        private PlayerShooting playerShooting;
        private EnemyDetection enemyDetection;
        private PlayerInputSystem playerInputSystem;
        private PlayerHealth playerHealth;  

        /// <summary>
        /// Parametrs to settring in incpector
        /// </summary>
        [Header("Player Settings")]
        [SerializeField] private int playerMaxHealth = 100;
        [SerializeField] private float _playerMoveSpeed = 40f;
        [SerializeField] private float _fireSpeed = 10f;
        [SerializeField] private float _playerAttackRadius = 10f;


        /// <summary>
        /// Prefabs
        /// </summary>
        [Header("Game Prefabs")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePoint;

        [SerializeField] private LayerMask _enemyLayerMask;

        [SerializeField] private Slider playerHealthSlider;
        [SerializeField] private PlayerUI playerUI;

        private void Awake()
        {
            playerShooting = GetComponent<PlayerShooting>();
            enemyDetection = GetComponent<EnemyDetection>();
            playerInputSystem = GetComponent<PlayerInputSystem>();
            playerHealth = GetComponent<PlayerHealth>();
        }

        private void Start()
        {
            playerShooting.Initialize(bulletPrefab, firePoint, _fireSpeed);
            enemyDetection.Initialize(_playerAttackRadius, _enemyLayerMask);
            playerInputSystem.Initialize(_playerMoveSpeed);
            playerHealth.Initialize(playerHealthSlider, playerUI, playerMaxHealth);
        }

        private void Update()
        {
            Transform nearestEnemy = enemyDetection.GetNearestEnemy();
            playerShooting.HandleShooting(nearestEnemy);
            playerInputSystem.HandleMovement();
        }
    }

}

