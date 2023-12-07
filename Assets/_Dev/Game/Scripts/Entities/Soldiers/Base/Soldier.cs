using System;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Units;

namespace _Dev.Game.Scripts.Entities.Soldiers.Base
{
    public abstract class Soldier : Attacker
    {
        private void OnEnable()
        {
            gameObject.layer = (int)LayerId.Player;
        }

        protected override bool IsAttackTarget(Unit unit)
        {
            return unit is Enemy;
        }
    }
}