using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WeaponAngle : WeaponShootLimit
{
    [SerializeField] private int amountPerShot = 4;
    [SerializeField] private float angle = 25;


    protected override void Shoot()
    {
        int mult = 0;
        for (int i = 0; i < amountPerShot; i++)
        {
            if(i%2 == 0)
                mult++;

            var prefab = Instantiate(prefabProjectile, shootingPosition);
            prefab.transform.localPosition = Vector3.zero;
            prefab.transform.localEulerAngles = Vector3.up * (i%2 == 0 ? angle : -angle) * mult;
            prefab.speed = shootingSpeed;
            prefab.transform.parent = null;
        }

    }

}
