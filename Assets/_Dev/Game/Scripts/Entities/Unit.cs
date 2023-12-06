using _Dev.Game.Scripts.Components;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities
{
    public abstract class Unit : MonoBehaviour
    {
        private HealthComponent _health;
        
        public HealthComponent GetHealth()
        {
            return _health;
        }

        private void Die()
        {
            
        }
    }
}