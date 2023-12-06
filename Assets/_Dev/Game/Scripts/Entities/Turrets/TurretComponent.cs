using _Dev.Game.Scripts.Entities.Turrets.Base;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class TurretComponent : MonoBehaviour
    {
        private Turret _turret = new Turret1();

        private void UpgradeTurret()
        {
            //todo: add upgrade logic
        }
    }
}