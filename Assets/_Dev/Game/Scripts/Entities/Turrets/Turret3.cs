using _Dev.Game.Scripts.Entities.Turrets.Base;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret3 : Turret
    {
        public override float GetAttackInterval => 0.5f;
        public override int GetAttackDamage => 20;

        public override void Attack()
        {
            Debug.Log($"attack!!");
        }
    }
}