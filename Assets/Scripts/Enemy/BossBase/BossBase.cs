using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy;
using Unity.VisualScripting;

namespace Boss
{

    public class BossBase : EnemyBase
    {

        [SerializeField] private float speed = 5f;
        [SerializeField] private int attackAmount = 2;
        [SerializeField] private int attacks = 0;
        [SerializeField] private GameObject player;
        [SerializeField] private List<Transform> waypoints;
        [SerializeField] private WeaponShootLimit weaponBase;

        protected override void Init()
        {
            currentLife = startLife;
            GoToRandomPoint();
        }

        private void Update()
        {
            if (player != null)
                transform.LookAt(player.transform.position);
        }

        private void GoToRandomPoint()
        {
            StartCoroutine(GoToPointCoroutine(waypoints[Random.Range(0, waypoints.Count)]));
        }

        IEnumerator GoToPointCoroutine(Transform t)
        {
            while (Vector3.Distance(transform.position, t.position) > 1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, t.position, Time.deltaTime * speed);
                yield return null;
            }
            StartCoroutine(StartShootingCoroutine());
        }

        IEnumerator StartShootingCoroutine()
        {
            weaponBase.StartShooting();
            while (true)
            {
                if (weaponBase._recharging)
                {
                    weaponBase.StopShooting();
                    GoToRandomPoint();
                    yield break;
                }
                yield return null;

            }
        }
    }

}