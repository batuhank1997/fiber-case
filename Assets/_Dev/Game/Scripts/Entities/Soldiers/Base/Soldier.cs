using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Units;

namespace _Dev.Game.Scripts.Entities.Soldiers.Base
{
    public abstract class Soldier : Attacker
    {
        protected override bool IsAttackTarget(Unit unit)
        {
            return unit is Enemy;
        }
    }
}