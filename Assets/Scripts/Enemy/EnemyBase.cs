using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Enemy{

    public class EnemyBase : MonoBehaviour, IDamageable
    {
        private float startLife = 10;
        [SerializeField]private float currentLife;


        //[Header("Start Animation")]

        private void Awake()
        {
            Init();
        }

        private void Init()
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
    }


}