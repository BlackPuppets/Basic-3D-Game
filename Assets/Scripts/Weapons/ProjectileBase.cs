using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [SerializeField] private float aliveDuration = 2f;
    [SerializeField] private int damageAmount = 1;
    public float speed = 50f;

    private void Awake()
    {
        Destroy(gameObject, aliveDuration);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var damageable = collision.transform.GetComponent<IDamageable>();

        if (damageable != null) damageable.TakeDamage(damageAmount);

        Destroy(gameObject);
    }
}
