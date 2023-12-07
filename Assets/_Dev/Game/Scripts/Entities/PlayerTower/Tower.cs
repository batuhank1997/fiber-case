using System;
using System.Collections.Generic;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Turrets.Base;
using _Dev.Game.Scripts.Entities.Units;
using _Dev.Game.Scripts.EventSystem;
using _Dev.Game.Scripts.UI;
using _Dev.Game.Scripts.UI.Views;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.PlayerTower
{
    public class Tower : Unit
    {
        [SerializeField] private List<TurretComponent> m_turrets;
        
        private void OnEnable()
        {
            SetLayer();
            InitTurrets();
            EventSystemManager.AddListener(EventId.on_object_clicked, OnObjectClick);
        }

        private void OnDisable()
        {
            EventSystemManager.RemoveListener(EventId.on_object_clicked, OnObjectClick);
        }

        private void OnObjectClick(EventArgs obj)
        {
            if (obj is not ObjectArguments args || (GameObject)args.Obj != gameObject) 
                return;
            
            //todo: show buy turret panel
            var turretView = ViewFactory.GetOrCreate<BuyTurretView>() as BuyTurretView;
            turretView.SetPanel(OnBuyTurret);
        }

        private void OnBuyTurret()
        {
            Debug.Log("Buy turret");
        }

        private void SetLayer()
        {
            gameObject.layer = (int)LayerId.Player;
        }
        
        private void InitTurrets()
        {
            foreach (var turret in m_turrets)
                turret.Init();
        }
    }
}