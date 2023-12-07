using System;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Projectiles;
using _Dev.Game.Scripts.Entities.Units;
using _Dev.Game.Scripts.EventSystem;
using _Dev.Game.Scripts.Managers;
using _Dev.Game.Scripts.UI;
using _Dev.Game.Scripts.UI.Views;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Turrets.Base
{
    public class TurretComponent : Attacker
    {
        [SerializeField] protected ProjectileComponent m_projectilePrefab;
        [SerializeField] protected Transform m_projectileSpawnPoint;
        
        [SerializeField] private MeshRenderer m_turretMeshRenderer;
        [SerializeField] private Material m_defaultMaterial;
        [SerializeField] private Material m_selectedMaterial;

        private int _turretLevel = 1;
        private string _turretKey;

        protected override float _attackInterval
        {
            get => _turret.AttackInterval;
            set => _delay = new WaitForSeconds(value);
        }

        private Turret _turret;
        
        public void Init(int index)
        {
            _turretKey = $"turret_{index}";
            
            SetTurret(LoadTurret());
            StartCoroutine(StartDetectingRoutine());
            EventSystemManager.AddListener(EventId.on_object_clicked, OnObjectClicked);
            EventSystemManager.AddListener(EventId.on_view_closed, OnUIClosed);
        }

        private void OnDestroy()
        {
            EventSystemManager.RemoveListener(EventId.on_object_clicked, OnObjectClicked);
            EventSystemManager.RemoveListener(EventId.on_view_closed, OnUIClosed);
        }
        
        public Turret GetTurret()
        {
            return _turret;
        }
        
        private Turret LoadTurret()
        {
            _turretLevel = SaveManager.LoadValue(_turretKey, 1);

            return _turretLevel switch
            {
                1 => new Turret1(),
                2 => new Turret2(),
                3 => new Turret3(),
                _ => null
            };
        }

        private void OnObjectClicked(EventArgs obj)
        {
            if (obj is not ObjectArguments args || (GameObject)args.Obj != gameObject) 
                return;

            SetMaterial(m_selectedMaterial);
            UpdateUpgradePanel();
        }
        
        
        private void OnUIClosed(EventArgs obj)
        {
            if (((TypeArguments)obj).Type == typeof(TurretUpgradeView))
                SetMaterial(m_defaultMaterial);
        }

        private void SetMaterial(Material selectedMaterial)
        {
            m_turretMeshRenderer.material = selectedMaterial;
        }

        private void SetTurret(Turret turret)
        {
            _turret = turret;
            _attackInterval = _turret.AttackInterval;
        }
        
        private void UpgradeTurret()
        {
            var price = _turret.TurretData.TurretPrice;
            if (ResourcesManager.GetResource() < price) return;

            ResourcesManager.ConsumeResource(price);
            _turret = _turret.Upgrade();
            _turretLevel = _turret.TurretData.Level;
            SaveManager.SaveValue(_turretKey, _turretLevel);
            UpdateUpgradePanel();
        }

        private void UpdateUpgradePanel()
        {
            var upgradePanel = ViewFactory.GetOrCreate<TurretUpgradeView>() as TurretUpgradeView;
            upgradePanel.SetPanel(this, UpgradeTurret);
        }
        
        protected override void Attack(Unit enemy)
        {
            var projectile = Instantiate(m_projectilePrefab, m_projectileSpawnPoint.position, Quaternion.identity);
            projectile.Init(_turret.Projectile, enemy.transform);
            enemy.GetHealth().OnDie += () =>
            {
                if (projectile)
                    Destroy(projectile.gameObject);
            };
        }
        
        protected override bool IsAttackTarget(Unit unit)
        {
           return unit is Enemy;
        }

    }
}