using _Dev.Game.Scripts.Entities.Turrets.Base;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret3 : Turret
    {
        protected override void Attack()
        {
            Debug.Log($"attack!!");
        }
    }
}