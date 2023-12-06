using _Dev.Game.Scripts.UI.Views.Base;
using _Dev.Utilities.Singleton;

namespace _Dev.Game.Scripts.UI
{
    public class ViewFactory : Singleton<ViewFactory>
    {
        private static View _existingUIController;

        public static View Create<T>() where T : View
        {
            if (IsExists<T>())
                return _existingUIController;
            
            var viewPrefab = ViewContainer.Instance.GetViewPrefab<T>();
            var instance = Instantiate(viewPrefab, Instance.transform);

            return instance;
        }
        
        //todo: refactor this
        public static bool IsExists<T>() where T : View
        {
            _existingUIController = FindObjectOfType<T>();
            return _existingUIController;
        }
    }
}