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
        private PlayerPoints playerPoints; //?

        /// <summary>
        /// Parametrs to settring in incpector
        /// </summary>
        [Header("Player Settings")]
        [SerializeField] private int playerMaxHealth = 100;
        [SerializeField] private float _playerMoveSpeed = 40f;

        [Header("Player Attack Settings")]
        [SerializeField] private float _fireSpeed = 10f;
        [SerializeField] private float _playerAttackRadius = 10f;


        /// <summary>
        /// Prefabs
        /// </summary>
        [Header("Game Prefabs")]
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform firePoint;

        [Header("Enemy Layer")]
        [SerializeField] private LayerMask _enemyLayerMask;

        [Header("Player UI Component")]
        [SerializeField] private Slider playerHealthSlider;
        [SerializeField] private PlayerUI playerUI;
        [SerializeField] private Text pointsText; //?

        private void Awake()
        {
            playerShooting = GetComponent<PlayerShooting>();
            enemyDetection = GetComponent<EnemyDetection>();
            playerInputSystem = GetComponent<PlayerInputSystem>();
            playerHealth = GetComponent<PlayerHealth>();
            playerPoints = GetComponent<PlayerPoints>(); //?
        }

        private void Start()
        {
            playerShooting.Initialize(bulletPrefab, firePoint, _fireSpeed);
            enemyDetection.Initialize(_playerAttackRadius, _enemyLayerMask);
            playerInputSystem.Initialize(_playerMoveSpeed);
            playerHealth.Initialize(playerHealthSlider, playerUI, playerMaxHealth);
            playerPoints.Initialize(this); //?
        }

        private void Update()
        {
            Transform nearestEnemy = enemyDetection.GetNearestEnemy();
            playerShooting.HandleShooting(nearestEnemy);
            playerInputSystem.HandleMovement();
        }

    }

}

