using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] protected ProjectileBase prefabProjectile;

    [SerializeField] protected Transform shootingPosition;
    [SerializeField] protected float shootingInterval;
    [SerializeField] protected float shootingSpeed = 50f;

    private Coroutine _currentCoroutine;

    [SerializeField] private KeyCode shootButton = KeyCode.Mouse0;

    protected virtual IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(shootingInterval);
        }
    }

    protected virtual void Shoot()
    {
        var prefab = Instantiate(prefabProjectile, shootingPosition);
        prefab.transform.localPosition = prefab.transform.localEulerAngles = Vector3.zero;
        prefab.speed = shootingSpeed;
        prefab.transform.parent = null;

    }

    public void StartShooting()
    {
        StopShooting();
        _currentCoroutine = StartCoroutine(ShootingCoroutine());
    }

    public void StopShooting()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
    }
}
