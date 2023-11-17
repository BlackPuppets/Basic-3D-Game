using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private Vector3 cameraOffset = new Vector3(0, 5.1f, -6.6f);
    void Update()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
