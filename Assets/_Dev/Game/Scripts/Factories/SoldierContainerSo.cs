using _Dev.Game.Scripts.Entities.Soldiers.Base;
using _Dev.Utilities.Singleton;
using UnityEngine;

namespace _Dev.Game.Scripts.Factories
{
    [CreateAssetMenu(fileName = "SoldierContainer", menuName = "ScriptableObjects/SoldierContainer", order = 1)]
    public class SoldierContainerSo : ScriptableSingleton<SoldierContainerSo>
    {
        public Soldier SoldierPrefab;
    }
}