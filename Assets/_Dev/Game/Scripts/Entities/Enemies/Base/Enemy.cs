using System;
using _Dev.Game.Scripts.Entities.Interface;

namespace _Dev.Game.Scripts.Entities.Enemies.Base
{
    [Serializable]
    public abstract class Enemy : Attacker
    {
        public void StartMoving(Tower.Tower waveTarget)
        {
            
        }
    }
}
