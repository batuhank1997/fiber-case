using System.Collections.Generic;
using _Dev.Game.Scripts.Entities.Turrets.Base;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Tower
{
    public class Tower : Unit
    {
        [SerializeField] private List<Turret> m_turrets;
        
        private void Start()
        {
            foreach (var turret in m_turrets)
            {
                turret.Init();
            }
        }
    }
}