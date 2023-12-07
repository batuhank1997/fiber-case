using _Dev.Game.Scripts.Components;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Units
{
    [RequireComponent(typeof(HealthComponent))]
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] protected HealthComponent m_health;
        
        public HealthComponent GetHealth()
        {
            return m_health;
        }
    }
}