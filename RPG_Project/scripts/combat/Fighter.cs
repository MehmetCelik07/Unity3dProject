using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using RPG.movement;
using RPG.core;

namespace RPG.combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float timeBetweenAttack = 1f;
        
        healt targetObject;
        float timeSinceLastAttack;
       
        [SerializeField] Weapon DefultWeapon = null;
        [SerializeField] Transform handTransform = null;
        

        private void Start()
        {
            spawnWeapon(DefultWeapon);
        }

        void Update()
        {
            
            timeSinceLastAttack += Time.deltaTime;
            if (targetObject == null)
            {
                return;
            }
            if (targetObject.IsDead() == true)
            {
                GetComponent<Animator>().ResetTrigger("Attack01");
                Cancel();
                return;
            }
            

            if (GetInRange() == false)
            {
                GetComponent<mover>().MoveTo(targetObject.transform.position,1f);
            }
            else
            {
                attackMethod();
                GetComponent<mover>().Cancel();
            }
        }

        public void spawnWeapon(Weapon weapon)
        {
            DefultWeapon = weapon;
            Animator animator = GetComponent<Animator>();
            DefultWeapon.Spawn(handTransform, animator);
        }
        private void attackMethod()
        {
            transform.LookAt(targetObject.transform);
            if (timeSinceLastAttack>timeBetweenAttack)
            {
                TriggerAttack();
                timeSinceLastAttack = 0;

            }




        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("stopAttack");
            GetComponent<Animator>().SetTrigger("Attack01");
        }

        void Hit()
        {
            if (targetObject == null)
            {
                return;
            }
            targetObject.takeDamage(DefultWeapon.GetDamage());
        }

        private bool GetInRange()
        {
            return Vector3.Distance(transform.position, targetObject.transform.position) < DefultWeapon.GetRange();
        }

        public void attack(GameObject target)
        {
            GetComponent<actionScheduler>().startAction(this);
            targetObject = target.GetComponent<healt>();

        }

        public bool canAttack(GameObject combatTarget)
        {
            if (combatTarget == null)
            {
                return false;
            }
            healt healtTotest = GetComponent<healt>();
            return healtTotest != null && !healtTotest.IsDead();
        }
        public void Cancel()
        {
            StopAttack();
            targetObject = null;
        }

        private void StopAttack()
        {
            GetComponent<Animator>().ResetTrigger("Attack01");
            GetComponent<Animator>().SetTrigger("stopAttack");
        }

      
    }

}
