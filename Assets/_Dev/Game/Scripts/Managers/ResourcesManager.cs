using _Dev.Game.Scripts.EventSystem;
using _Dev.Utilities.Singleton;
using UnityEngine;

namespace _Dev.Game.Scripts.Managers
{
    public class ResourcesManager : Singleton<ResourcesManager>
    {
        private const string RESOURCE_ID = "soft_currency";
        
        public static void AddResource(int amount)
        {
            var currentAmount = SaveManager.LoadValue(RESOURCE_ID.ToString(), 0);
            var newAmount = currentAmount + amount;
            EventSystemManager.InvokeEvent(EventId.on_resource_added, new IntArguments(amount));
        }
    
        public static void ConsumeResource(int amount)
        {
            var currentAmount = SaveManager.LoadValue(RESOURCE_ID.ToString(), 0);
            var newAmount = Mathf.Max(0, currentAmount - amount);
            SaveManager.SaveValue(RESOURCE_ID.ToString(), newAmount);
            EventSystemManager.InvokeEvent(EventId.on_resource_consumed, new IntArguments(amount));
        }
        
        public static void ResetResource()
        {
            EventSystemManager.InvokeEvent(EventId.on_resource_reset);
            SaveManager.SaveValue(RESOURCE_ID.ToString(), 0);
        }
    
        public static int GetResource()
        {
            if (SaveManager.IsKeyExist(RESOURCE_ID.ToString()))
                return SaveManager.LoadValue(RESOURCE_ID.ToString(), 0);
            
            return 0;
        }
    }
}
