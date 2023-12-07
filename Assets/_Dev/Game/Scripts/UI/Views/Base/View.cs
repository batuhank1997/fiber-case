using System;
using UnityEngine;

namespace _Dev.Game.Scripts.UI.Views.Base
{
    public abstract class View : MonoBehaviour
    {
        public virtual void Show()
        {
            
        }
        
        public virtual void Hide()
        {
            Destroy(gameObject);
        }
        
        protected virtual void OnEnable()
        {
            Show();
        }

        protected virtual void OnDisable()
        {
            Hide();
        }
    }
}
