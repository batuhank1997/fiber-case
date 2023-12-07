using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Projectiles
{
    public class ExplosiveProjectile : Base.Projectile
    {
        protected override int _damageAmount => ProjectileDataContainerSo.Instance.ExplosiveProjectileData.DamageAmount;

        public override void DealDamage(Unit unit)
        {
            var colliders = new Collider[10];
            var size = Physics.OverlapSphereNonAlloc(unit.transform.position, 5f, colliders);

            for (var i = 0; i < size; i++)
            {
                if (colliders[i].TryGetComponent<Unit>(out var unitComponent))
                    unitComponent.GetHealth().Damage(_damageAmount);
            }
        }
    }
}