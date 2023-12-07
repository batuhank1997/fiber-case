using _Dev.Game.Scripts.EventSystem;
using UnityEngine;

namespace _Dev.Game.Scripts.UI.Views.Base
{
    public abstract class View : MonoBehaviour
    {
        public virtual void Show()
        {
            EventSystemManager.InvokeEvent(EventId.on_view_shown, new TypeArguments(GetType()));
        }
        
        public virtual void Hide()
        {
            EventSystemManager.InvokeEvent(EventId.on_view_closed, new TypeArguments(GetType()));
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
