using System;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Projectiles
{
    public class ProjectileComponent : MonoBehaviour
    {
        private Base.Projectile _projectile;
        private Transform _target;

        public void Init(Base.Projectile projectile, Transform target)
        {
            _projectile = projectile;
            _target = target;
        }

        private void Update()
        {
            if (_target == null) return;

            Move();
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, 10f * Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("OnTriggerEnter");
            var unit = other.GetComponent<Unit>();
            if (unit == null) return;
            Debug.Log("Unit is not null");
            _projectile.DealDamage(unit);
            Destroy(gameObject);
        }
    }
}