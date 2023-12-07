﻿using System;
using System.Collections.Generic;
using _Dev.Game.Scripts.Entities.Enemies.Base;
using _Dev.Game.Scripts.Entities.Turrets.Base;
using _Dev.Game.Scripts.Entities.Units;
using _Dev.Game.Scripts.EventSystem;
using _Dev.Game.Scripts.Factories;
using _Dev.Game.Scripts.Managers;
using _Dev.Game.Scripts.UI;
using _Dev.Game.Scripts.UI.Views;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.PlayerTower
{
    public class Tower : Unit
    {
        [SerializeField] private TurretComponent m_turretPrefab;
        [SerializeField] private List<TurretComponent> m_turrets;
        
        [SerializeField] private List<Transform> m_turretSpawnPoints;
        [SerializeField] private Transform m_soldierSpawnPoint;

        private int _boughtTurretsAmount = 0;
        private const string TURRETS_AMOUNT_KEY = "turrets";
        
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
            
            var buyView = ViewFactory.GetOrCreate<BuyView>() as BuyView;
            buyView.SetPanel(OnBuyTurret, OnBuySoldier);
        }

        private void OnBuyTurret()
        {
            if (ResourcesManager.GetResource() < 100) 
                return;

            ResourcesManager.ConsumeResource(100);
            SpawnTurret();
        }
        
        private void OnBuySoldier()
        {
            if (ResourcesManager.GetResource() < 100) 
                return;
            
            ResourcesManager.ConsumeResource(100);
            SpawnSoldier();
        }

        private void SpawnSoldier()
        {
            var soldier = SoldierFactory.Create();
            soldier.transform.position = m_soldierSpawnPoint.position;
        }

        private void SpawnTurret()
        {
            if (_boughtTurretsAmount >= m_turretSpawnPoints.Count)
                return;
            
            var turret = Instantiate(m_turretPrefab, m_turretSpawnPoints[_boughtTurretsAmount].position, Quaternion.identity);
            turret.transform.SetParent(transform);
            turret.Init(_boughtTurretsAmount);
            _boughtTurretsAmount++;
            m_turrets.Add(turret);
            SaveManager.SaveValue(TURRETS_AMOUNT_KEY, _boughtTurretsAmount);
        }

        private void SetLayer()
        {
            gameObject.layer = (int)LayerId.Player;
        }
        
        private void InitTurrets()
        {
            var turretsAmount = SaveManager.LoadValue(TURRETS_AMOUNT_KEY, 1);
            
            for (var i = 0; i < turretsAmount; i++)
                SpawnTurret();
        }
    }
}