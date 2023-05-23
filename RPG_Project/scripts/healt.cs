using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.core
{
    public class healt : MonoBehaviour
    {
        [SerializeField] float healthss = 100f;
        bool isDead=false;

        public bool IsDead()
        {
            return isDead;
        }

        public void takeDamage(float damage)
        {
            
            healthss = Mathf.Max(healthss - damage, 0);
            if (healthss == 0)
            {
                Die();
            }

        }

        private void Die()
        {
            if (isDead==true)
            {
                return;
            }
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<actionScheduler>().cancelCurrentAction();
        }
    }
}

