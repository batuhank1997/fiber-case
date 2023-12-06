namespace _Dev.Game.Scripts.Entities.Interface
{
    public interface IAttacker
    {
        int GetAttackInterval { get; }
        int GetAttackDamage { get; }
        void StartAttack();
        void Attack();
    }
}