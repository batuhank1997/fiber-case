﻿using System.Collections.Generic;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Turrets.Base;
using _Dev.Game.Scripts.Entities.Units;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.PlayerTower
{
    public class Tower : Unit
    {
        [SerializeField] private List<TurretComponent> m_turrets;
        
        private void Start()
        {
            gameObject.layer = (int)LayerId.Player;
            
            foreach (var turret in m_turrets)
                turret.Init();
        }
    }
}