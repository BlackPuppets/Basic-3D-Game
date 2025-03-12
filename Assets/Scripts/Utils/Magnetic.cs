using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetic : MonoBehaviour
{
    [SerializeField] private float dist = 2f;
    [SerializeField] private float coinSpeed = 3f;

    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerMovement.instance.transform.position) > dist)
        {
            coinSpeed++;
            transform.position = Vector3.MoveTowards(transform.position, PlayerMovement.instance.transform.position, Time.deltaTime * coinSpeed);
        }
    }
}
