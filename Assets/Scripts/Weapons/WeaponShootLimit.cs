using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShootLimit : WeaponBase
{
    [SerializeField]private float maxShots = 5f;
    [SerializeField] private float timeToRecharge = 1f;

    private float _currentShots;
    private bool _recharging = false;

    protected override IEnumerator ShootingCoroutine()
    {
        if (_recharging) yield break;

        while (true)
        {
            if (_currentShots < maxShots)
            {
                Shoot();
                _currentShots++;
                CheckRecharge();
                yield return new WaitForSeconds(shootingInterval);
            }
        }
    }

    private void CheckRecharge()
    {
        if (_currentShots >= maxShots)
        {
            StopShooting();
            StartRecharge();
        }
    }

    private void StartRecharge()
    {
        _recharging = true;
        StartCoroutine(RechargingCoroutine());
    }

    IEnumerator RechargingCoroutine()
    {
        float time = 0;
        while (time < timeToRecharge)
        {
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        _currentShots = 0;
        _recharging = false;
    }
}
