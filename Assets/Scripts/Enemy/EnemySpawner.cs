using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


namespace TDS.Scripts.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Prefabs")]
        [SerializeField] private GameObject[] _enemyPrefabs;
        [SerializeField] private GameObject _bossPrefab;

        [Header("Enemy Settings")]
        [SerializeField] private EnemySettings[] _enemySettings;
        [SerializeField] private EnemySettings _bossSettings;
        
        [Header("Enemy SpawnPoints")]
        [SerializeField] Transform[] _spawnPoints;

        [Header("Wave settings")]
        [SerializeField] private float _timeBetweenWaves = 5f;
        [SerializeField] private Wave[] waves;

        [Header("UI Component")]
        [SerializeField] private Text _waveText;
        [SerializeField] private Text _points;

        private int currentWaveIndex = 0;

        private void Start()
        {
            StartCoroutine(SpawnWaves());
        }

        IEnumerator SpawnWaves()
        {
            while(currentWaveIndex < waves.Length)
            {
                Wave currentWave = waves[currentWaveIndex];
                UpdateWaveText();
                yield return StartCoroutine(SpawnEnemies(currentWave));

                currentWaveIndex++;
                yield return new WaitForSeconds(_timeBetweenWaves);
            }
        }

        IEnumerator SpawnEnemies(Wave wave)
        {
            for(int i = 0; i < wave.enemyCount; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(1f);
            }
            if (wave.spawnBoss)
            {
                SpawnBoss();
            }
        }

        private void SpawnEnemy()
        {
            int spawnIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
            GameObject enemyPrefab = _enemyPrefabs[UnityEngine.Random.Range(0, _enemyPrefabs.Length)];
            EnemySettings settings = _enemySettings[UnityEngine.Random.Range(0, _enemySettings.Length)];

            GameObject enemyGO = Instantiate(enemyPrefab, _spawnPoints[spawnIndex].position, _spawnPoints[spawnIndex].rotation);
            IEnemy enemy = enemyGO.GetComponent<IEnemy>();

            if(enemy != null)
            {
                enemy.Instialize(GameObject.FindGameObjectWithTag("Player").transform, settings);
            }
        }

        private void SpawnBoss()
        {
            int spawnIndex = UnityEngine.Random.Range(0, _spawnPoints.Length);
            GameObject bossGO = Instantiate(_bossPrefab, _spawnPoints[spawnIndex].position, _spawnPoints[spawnIndex].rotation);
            IEnemy boss = bossGO.GetComponent<IEnemy>();

            if (boss != null)
            {
                boss.Instialize(GameObject.FindGameObjectWithTag("Player").transform, _bossSettings);
            }
        }

        private void UpdateWaveText()
        {
            _waveText.text = "Wave " + (currentWaveIndex + 1);
        }


        [Serializable]
        public class Wave
        {
            public int enemyCount;
            public bool spawnBoss;
        }
    }
}
