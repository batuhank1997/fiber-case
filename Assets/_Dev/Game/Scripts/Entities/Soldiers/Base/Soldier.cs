using _Dev.Game.Scripts.Entities.Interface;

namespace _Dev.Game.Scripts.Entities.Soldiers.Base
{
    public abstract class Soldier : IAttacker
    {
        public float GetAttackInterval { get; }
        public int GetAttackDamage { get; }
        
        public void Attack()
        {
            
        }
    }
}