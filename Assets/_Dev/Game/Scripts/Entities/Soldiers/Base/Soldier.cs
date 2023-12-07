using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Soldiers.Base
{
    public abstract class Soldier : Attacker
    {
        protected override float _attackInterval
        {
            get => m_attackInterval;
            set => _delay = new WaitForSeconds(value);
        }
        
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