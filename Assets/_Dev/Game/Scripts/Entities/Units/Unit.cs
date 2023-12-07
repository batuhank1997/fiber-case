using _Dev.Game.Scripts.Components;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Dev.Game.Scripts.Entities.Units
{
    [RequireComponent(typeof(HealthComponent))]
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] private HealthComponent m_health;
        
        public HealthComponent GetHealth()
        {
            return m_health;
        }
    }
}