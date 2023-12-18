using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyWalk : EnemyBase
    {
        public GameObject[] waypoints;
        [SerializeField]private GameObject player;
        [SerializeField] private float minDistance = 1f;
        [SerializeField]private float speed = 5f;

        private int index = 0;

        private void Update()
        {
            if (Vector3.Distance(transform.position, waypoints[index].transform.position) < minDistance)
            {
                index++;
                if (index >= waypoints.Length)
                {
                    index = 0;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[index].transform.position, Time.deltaTime * speed);
            if(player != null)
                transform.LookAt(player.transform.position);
        }
    }
}
