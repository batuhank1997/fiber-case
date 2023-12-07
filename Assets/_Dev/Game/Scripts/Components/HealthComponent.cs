using System;
using UnityEngine;

namespace _Dev.Game.Scripts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int m_value = 100;

        public Action OnDie;

        private void OnEnable()
        {
            OnDie += Die;
        }
        
        private void OnDisable()
        {
            OnDie -= Die;
        }

        public void Damage(int amount)
        {
            m_value -= amount;

            if (m_value <= 0)
                OnDie?.Invoke();
        }
        public void Heal(int amount)
        {
            m_value += amount;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}