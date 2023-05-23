using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.movement;
using RPG.combat;
using RPG.core;
using System;

namespace RPG.controller
{
   
    public class PlayerController : MonoBehaviour
    {
        healt health;
        
        void Start()
        {
            health = GetComponent<healt>();
        }
        
        void Update()
        {

            if (health.IsDead()==true)
            {
                return;
            }                
            if (InteractWithCombat())
            {
                return;
            }
            if (InteractWithMovement())
            {
                return;
            }
            
        }

       bool InteractWithCombat()
        {

            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                combatTarget target = hit.transform.GetComponent<combatTarget>();

                if (target == null)
                {
                    continue;
                }
                if (!GetComponent<Fighter>().canAttack(target.gameObject))
                {
                    continue;
                }
                if (target == null)
                {
                    continue;
                }
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Fighter>().attack(target.gameObject);
                }
                return true;
            }
            return false;

        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        bool InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<mover>().StartMoveAction(hit.point, 1f);
                }
                return true;
            }
            return false;
        }

     
    }
}

