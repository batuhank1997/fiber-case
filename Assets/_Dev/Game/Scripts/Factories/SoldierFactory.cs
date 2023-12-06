using System.Linq;
using _Dev.Game.Scripts.Entities.Soldiers;
using _Dev.Game.Scripts.Entities.Soldiers.Base;
using _Dev.Utilities.Singleton;
using UnityEngine;

namespace _Dev.Game.Scripts.Factories
{
    public static class SoldierFactory
    {
        public static SoldierComponent Create<T>() where T : Soldier
        {
            var soldierPrefab = SoldierContainer.Instance.Soldiers
                .First(s => s.GetSoldier().GetType() == typeof(T));

            var soldier = Object.Instantiate(soldierPrefab);
            
            return soldier;
        }
    }

    [CreateAssetMenu(fileName = "SoldierContainer", menuName = "ScriptableObjects/SoldierContainer", order = 1)]
    public class SoldierContainer : ScriptableSingleton<SoldierContainer>
    {
        public SoldierComponent[] Soldiers;
    }
}