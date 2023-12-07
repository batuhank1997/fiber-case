using System;
using _Dev.Utilities.Singleton;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    [CreateAssetMenu(fileName = "TurretDataContainer", menuName = "ScriptableObjects/TurretDataContainer")]
    public class TurretDataContainerSo : ScriptableSingleton<TurretDataContainerSo>
    {
        public TurretData Turret1Data;
        public TurretData Turret2Data;
        public TurretData Turret3Data;
    }
    
        
    [Serializable]
    public class TurretData
    {
        public string Name;
        public int Level;
        public int TurretPrice;
    }
}
