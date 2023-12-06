using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Projectile
{
    public class ProjectileComponent : MonoBehaviour
    {
        private Projectile _projectile = new BasicProjectile();

        private void OnTriggerEnter(Collider other)
        {
            var unit = other.GetComponent<Unit>();
            if (unit == null) return;
            
            _projectile.DealDamage(unit);
            Destroy(gameObject);
        }
    }
}