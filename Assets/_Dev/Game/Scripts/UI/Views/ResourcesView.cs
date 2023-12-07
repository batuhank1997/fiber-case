using System;
using _Dev.Game.Scripts.EventSystem;
using _Dev.Game.Scripts.Managers;
using _Dev.Game.Scripts.UI.Views.Base;
using TMPro;
using UnityEngine;

namespace _Dev.Game.Scripts.UI.Views
{
    public class ResourcesView : View
    {
        [SerializeField] private TextMeshProUGUI m_resourcesText;
        
        protected override void OnEnable()
        {
            EventSystemManager.AddListener(EventId.on_resource_added, UpdateResources);
            EventSystemManager.AddListener(EventId.on_resource_consumed, UpdateResources);
            UpdateResources(default);
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            EventSystemManager.RemoveListener(EventId.on_resource_added, UpdateResources);
            EventSystemManager.RemoveListener(EventId.on_resource_consumed, UpdateResources);
            base.OnDisable();
        }

        private void UpdateResources(EventArgs obj)
        {
            m_resourcesText.text = ResourcesManager.GetResource().ToString();
        }
    }
}