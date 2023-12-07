using UnityEngine;

namespace _Dev.Game.Scripts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int m_value = 100;

        public void Damage(int amount)
        {
            m_value -= amount;

            if (m_value <= 0)
                Die();
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