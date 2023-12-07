using System;
using System.Collections;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Projectiles;
using _Dev.Game.Scripts.Entities.Units;
using _Dev.Game.Scripts.EventSystem;
using _Dev.Game.Scripts.UI;
using _Dev.Game.Scripts.UI.Views;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Turrets.Base
{
    public class TurretComponent : Attacker
    {
        [SerializeField] protected ProjectileComponent m_projectilePrefab;
        [SerializeField] protected Transform m_projectileSpawnPoint;
        
        private Turret _turret;
        
        public void Init()
        {
            SetTurret(new Turret1());
            StartCoroutine(StartDetectingRoutine());
            EventSystemManager.AddListener(EventId.on_object_clicked, OnObjectClicked);
        }

        private void OnDestroy()
        {
            EventSystemManager.RemoveListener(EventId.on_object_clicked, OnObjectClicked);
        }

        private void OnObjectClicked(EventArgs obj)
        {
            if (obj is not ObjectArguments args || (GameObject)args.Obj != gameObject) 
                return;

            ViewFactory.GetOrCreate<TurretUpgradeView>();
        }

        private void SetTurret(Turret turret)
        {
            _turret = turret;
        }

        protected override void Attack(Unit enemy)
        {
            var projectile = Instantiate(m_projectilePrefab, m_projectileSpawnPoint.position, Quaternion.identity);
            projectile.Init(_turret.Projectile, enemy.transform);
        }
        
        protected override bool IsAttackTarget(Unit unit)
        {
           return unit is Enemy;
        }
    }
}