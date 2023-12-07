using _Dev.Game.Scripts.UI;
using _Dev.Game.Scripts.UI.Views;
using _Dev.Utilities.Singleton;

namespace _Dev.Game.Scripts.Managers
{
    public class ViewManager : Singleton<ViewManager>
    {
        public void Initialize()
        {
            ViewFactory.Create<ResourcesView>();
            ViewFactory.Create<ProgressBarView>();
        }
    }
}