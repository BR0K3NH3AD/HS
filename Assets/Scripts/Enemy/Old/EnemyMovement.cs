using UnityEngine;

namespace TDS.Scripts.Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _enemySpeed;
        [SerializeField] private float _enemyRotationSpeed;

        private Rigidbody2D _rb2D;
        private EnemyLogick _enemyLogick;
        private Vector2 _targetDirection;

        private void Awake()
        {
            _rb2D = GetComponent<Rigidbody2D>();
            _enemyLogick = GetComponent<EnemyLogick>();
        }

        private void FixedUpdate()
        {
            UpdateTartgetDirection();
            RotateTowardsTarger();
            SetVelocity();
        }

        private void UpdateTartgetDirection()
        {
            _targetDirection = _enemyLogick.DirectionToPlayer;
        }

        private void RotateTowardsTarger()
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _enemyRotationSpeed * Time.deltaTime);

            _rb2D.SetRotation(rotation);
        }

        private void SetVelocity()
        {
            _rb2D.velocity = transform.up * _enemySpeed;
        }
    }

}

