using _Dev.Game.Scripts.Entities.Turrets.Base;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret2 : Turret
    {
        public override float GetAttackInterval => .8f;
        public override int GetAttackDamage => 15;

        public override void Attack()
        {
            Debug.Log($"attack!!");
        }
    }
}