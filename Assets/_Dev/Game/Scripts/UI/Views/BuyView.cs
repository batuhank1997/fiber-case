using System;
using _Dev.Game.Scripts.EventSystem;
using _Dev.Game.Scripts.UI.Views.Base;
using UnityEngine;
using UnityEngine.UI;

namespace _Dev.Game.Scripts.UI.Views
{
    public class BuyView : View
    {
        [SerializeField] private Button m_buyTurretButton;
        [SerializeField] private Button m_buySoldierButton;
        
        public void SetPanel(Action onBuyTurret, Action onBuySoldier)
        {
            m_buyTurretButton.onClick.AddListener(onBuyTurret.Invoke);
            m_buySoldierButton.onClick.AddListener(onBuySoldier.Invoke);

        }
        
        protected override void OnDisable()
        {
            m_buyTurretButton.onClick.RemoveAllListeners();
            base.OnDisable();
        }
    }
}
