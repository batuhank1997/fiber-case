using System.Linq;
using _Dev.Game.Scripts.Entities.Soldiers;
using _Dev.Game.Scripts.Entities.Soldiers.Base;
using UnityEngine;

namespace _Dev.Game.Scripts.Factories
{
    public static class SoldierFactory
    {
        public static Soldier Create()
        {
            var soldierPrefab = SoldierContainerSo.Instance.SoldierPrefab;
            var soldierComponent = Object.Instantiate(soldierPrefab);

            return soldierComponent;
        }
    }
}