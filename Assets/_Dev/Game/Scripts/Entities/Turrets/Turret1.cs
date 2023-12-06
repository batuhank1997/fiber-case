using _Dev.Game.Scripts.Entities.Turrets.Base;
using UnityEngine;

namespace _Dev.Game.Scripts.Entities.Turrets
{
    public class Turret1 : Turret
    {
        public override int GetAttackInterval => 1;
        public override int GetAttackDamage => 10;

        public override void Attack()
        {
            Debug.Log($"attack!!");
        }
    }
}