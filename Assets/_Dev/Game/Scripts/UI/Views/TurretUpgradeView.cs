using System;
using _Dev.Game.Scripts.Entities.Turrets.Base;
using _Dev.Game.Scripts.EventSystem;
using _Dev.Game.Scripts.UI.Views.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Dev.Game.Scripts.UI.Views
{
    public class TurretUpgradeView : View
    {
        [SerializeField] private TextMeshProUGUI m_turretName;
        [SerializeField] private TextMeshProUGUI m_turretLevel;
        [SerializeField] private TextMeshProUGUI m_nextLevelCost;
        
        [SerializeField] private Button m_upgradeButton;
        
        public void SetPanel(TurretComponent turret, Action onUpgrade)
        {
            m_turretName.text = turret.GetTurret().TurretData.Name;
            m_turretLevel.text = $"Level: {turret.GetTurret().TurretData.Level}";
            m_nextLevelCost.text = $"Next Level Cost: {turret.GetTurret().TurretData.TurretPrice}";
            m_upgradeButton.onClick.AddListener(() => onUpgrade?.Invoke());
        }

        protected override void OnDisable()
        {
            Debug.Log("VIEW CLOSED");
            m_upgradeButton.onClick.RemoveAllListeners();
            base.OnDisable();
        }
    }
}