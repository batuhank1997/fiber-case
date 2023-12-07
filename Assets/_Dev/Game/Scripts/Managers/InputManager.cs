using _Dev.Game.Scripts.EventSystem;
using _Dev.Game.Scripts.UI;
using _Dev.Game.Scripts.UI.Views;
using _Dev.Utilities.Singleton;
using UnityEngine;

namespace _Dev.Game.Scripts.Managers
{
    public class InputManager : Singleton<InputManager>
    {
        private Camera _mainCamera;
        
        public void Initialize()
        {
            _mainCamera = Camera.main;
        }
        
        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            HandleClick();
        }

        private void HandleClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetObjectUnderClickedPosition();
            }
        }

        private void GetObjectUnderClickedPosition()
        {
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                return;

            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (!Physics.Raycast(ray, out var hit))
            {
                ViewFactory.GetOrCreate<TurretUpgradeView>().Hide();
                return;
            }
            
            var hitObject = hit.collider.gameObject;
            EventSystemManager.InvokeEvent(EventId.on_object_clicked, new ObjectArguments(hitObject));
        }
    }
}