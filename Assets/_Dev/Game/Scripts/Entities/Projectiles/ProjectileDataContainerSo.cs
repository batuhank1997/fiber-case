using System;
using _Dev.Utilities.Singleton;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Projectiles
{
    [CreateAssetMenu(fileName = "ProjectileDataContainer", menuName = "ScriptableObjects/ProjectileDataContainer")]
    public class ProjectileDataContainerSo : ScriptableSingleton<ProjectileDataContainerSo>
    {
        public ProjectileData BasicProjectileData;
        public ProjectileData HeavyProjectileData;
        public ProjectileData SuperProjectileData;
        public ProjectileData ExplosiveProjectileData;
    }

    [Serializable]
    public class ProjectileData
    {
        public int DamageAmount;
    }
}