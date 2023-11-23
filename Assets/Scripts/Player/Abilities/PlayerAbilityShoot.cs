using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{

    [SerializeField] private WeaponBase[] weaponBaseArray;
    [SerializeField] private List<WeaponBase> currentWeapons;
    [SerializeField] private WeaponBase currentWeapon;
    [SerializeField] private Transform weaponPosition;

    protected override void Init()
    {
        base.Init();
        currentWeapons = new List<WeaponBase>();
        InstantiateGuns();
        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => CancelShoot();
        inputs.Gameplay.ChangeWeapon_1.performed += cts => ChangeWeapon(0);
        inputs.Gameplay.ChangeWeapon_2.performed += cts => ChangeWeapon(1);
    }

    void InstantiateGuns()
    {
        foreach (WeaponBase weapon in weaponBaseArray)
        {
            //currentWeapon
            var temporaryWeapon = Instantiate(weapon, weaponPosition);
            temporaryWeapon.transform.localPosition = temporaryWeapon.transform.localEulerAngles = Vector3.zero;
            if (weapon == weaponBaseArray[0])
            {
                currentWeapon = temporaryWeapon;
            }
            else
            {
                temporaryWeapon.gameObject.SetActive(false);
            }
            currentWeapons.Add(temporaryWeapon);

        }
    }

    private void StartShoot()
    {
        currentWeapon.StartShooting();
    }

    private void CancelShoot()
    {
        currentWeapon.StopShooting();
    }

    public void ChangeWeapon(int weaponIndex)
    {
        foreach(WeaponBase weapon in currentWeapons)
        {
            weapon.gameObject.SetActive(false);
        }
        currentWeapons[weaponIndex].gameObject.SetActive(true);
        currentWeapon = currentWeapons[weaponIndex];
    }

}
