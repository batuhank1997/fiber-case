using System;
using _Dev.Game.Scripts.EventSystem;
using _Dev.Game.Scripts.Managers;
using _Dev.Game.Scripts.UI.Views.Base;
using UnityEngine;
using UnityEngine.UI;

namespace _Dev.Game.Scripts.UI.Views
{
    public class ProgressBarView : View
    {
        [SerializeField] private Slider m_progressBar;
        
        protected override void OnEnable()
        {
            EventSystemManager.AddListener(EventId.on_enemy_died, UpdateProgress);
            EventSystemManager.AddListener(EventId.on_wave_started, ResetProgressBar);
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            EventSystemManager.RemoveListener(EventId.on_enemy_died, UpdateProgress);
            EventSystemManager.RemoveListener(EventId.on_wave_started, ResetProgressBar);
            base.OnDisable();
        }

        private void ResetProgressBar(EventArgs obj)
        {
            m_progressBar.value = 0;
        }
        
        private void UpdateProgress(EventArgs obj)
        {
            var total = WaveManager.Instance.GetWaveProgress();
            m_progressBar.value = total;
        }
    }
}