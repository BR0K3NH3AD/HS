using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.Scripts.Player
{
    public class PlayerShooting : MonoBehaviour
    {
        private GameObject bulletPrefab;
        private Transform firePoint;
        private float fireSpeed;
        private float fireCountDown = 0f;

        public void Initialize(GameObject bulletPrefab, Transform firePoint, float fireSpeed)
        {
            this.bulletPrefab = bulletPrefab;
            this.firePoint = firePoint;
            this.fireSpeed = fireSpeed;
        }

        public void HandleShooting(Transform target)
        {
            if (target != null && fireCountDown <= 0f)
            {
                Shoot(target);
                fireCountDown = 1f / fireSpeed;
            }

            fireCountDown -= Time.deltaTime;
        }

        private void Shoot(Transform target)
        {
            GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            if (bullet != null)
            {
                bullet.Seek(target);
            }
        }

        public void SetAttackSpeed(float newFireSpeed)
        {
            fireSpeed = newFireSpeed;
        } //?
    }
}
