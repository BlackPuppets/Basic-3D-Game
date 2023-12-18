using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy{

    public class EnemyBase : MonoBehaviour, IDamageable
    {
        protected float startLife = 10;
        [SerializeField]protected float currentLife;


        //[Header("Start Animation")]

        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            currentLife = startLife;
        }

        protected virtual void Kill()
        {
            OnKill();
        }

        protected virtual void OnKill() { 
            Destroy(gameObject);
        }

        public void OnDamage(float damage)
        {
            currentLife -= damage;
            if (currentLife <= 0)
            {
                Kill();
            }
        }

        public void TakeDamage(float damage)
        {
            OnDamage(damage);
        }

        private void OnCollisionEnter(Collision collision)
        {
            PlayerMovement player = collision.transform.GetComponent<PlayerMovement>();
            if(player != null)
            {
                player.TakeDamage(2);
            }
        }
    }


}