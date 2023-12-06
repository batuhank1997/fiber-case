using _Dev.Game.Scripts.Components;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Enemies.Base
{
    [RequireComponent(typeof(MoverComponent))]
    public abstract class Enemy : Attacker
    {
        [SerializeField] private MoverComponent m_mover;
        
        public void StartMoving(Transform target)
        {
            m_mover.SetMoveTarget(target);
        }
    }
}
