using System;
using _Dev.Game.Scripts.UI.Views.Base;
using UnityEngine;
using UnityEngine.UI;

namespace _Dev.Game.Scripts.UI.Views
{
    public class BuyTurretView : View
    {
        [SerializeField] private Button m_button;
        
        public void SetPanel(Action onClick)
        {
            m_button.onClick.AddListener(onClick.Invoke);
        }

        protected override void OnDisable()
        {
            m_button.onClick.RemoveAllListeners();
            base.OnDisable();
        }
    }
}
