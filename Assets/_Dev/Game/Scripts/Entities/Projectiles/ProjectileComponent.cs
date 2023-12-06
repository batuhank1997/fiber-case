using _Dev.Game.Scripts.Entities.Projectiles.Base;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Projectiles
{
    public class ProjectileComponent : MonoBehaviour
    {
        private Base.Projectile _projectile = new BasicProjectile();

        private void OnTriggerEnter(Collider other)
        {
            var unit = other.GetComponent<Unit>();
            if (unit == null) return;
            
            _projectile.DealDamage(unit);
            Destroy(gameObject);
        }
    }
}