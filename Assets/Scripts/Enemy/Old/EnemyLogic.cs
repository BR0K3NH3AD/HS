using System.Collections;
using System.Collections.Generic;
using TDS.Scripts.Player;
using UnityEngine;


namespace TDS.Scripts.Enemy
{
    public class EnemyLogick : MonoBehaviour
    {
        public Vector2 DirectionToPlayer { get; private set; }
        
        private Transform _player;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerInputSystem>().transform;
        }

        private void Update()
        {
            Vector2 enemyToPlayerVector = _player.position - transform.position;

            DirectionToPlayer = enemyToPlayerVector.normalized;


        }
    }

}
