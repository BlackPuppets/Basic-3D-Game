using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy
{
    public class EnemyShoot : EnemyBase
    {
        public WeaponBase weaponBase;

        protected override void Init()
        {
            base.Init();

            weaponBase.StartShooting();
        }
    }
}
