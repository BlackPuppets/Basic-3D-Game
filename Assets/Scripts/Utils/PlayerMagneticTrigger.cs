using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMagneticTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GenericCollectable i = other.GetComponent<GenericCollectable>();
        if (i != null)
        {
            i.AddComponent<Magnetic>();
        }
    }
}
