using UnityEngine;

namespace _Dev.Game.Scripts.Components
{
    public class HealthComponent : MonoBehaviour
    {
        public int Value { get; private set; }

        public void Damage(int amount)
        {
            Value -= amount;
        }
        public void Heal(int amount)
        {
            Value += amount;
        }
    }
}