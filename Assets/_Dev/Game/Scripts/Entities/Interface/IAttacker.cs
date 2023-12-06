using System.Collections;

namespace _Dev.Game.Scripts.Entities.Interface
{
    public interface IAttacker
    {
        int GetAttackInterval { get; }
        int GetAttackDamage { get; }
        IEnumerator StartAttackRoutine();
        void Attack();
    }
}