using RPG.combat;
using RPG.core;
using RPG.movement;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.controller
{
    public class AIcontroller : MonoBehaviour
    {
        GameObject player;
        Fighter fighter;
        [SerializeField] float chaseDistance = 5f;
        [SerializeField] float suspicionTime = 5f;
        [SerializeField] PatrolPath patrolPath;
        [SerializeField] float wayPointTolerance = 1f;
        [SerializeField] float wayPointLifeTime = 3f;
        [Range(0,1)]
        [SerializeField] float patrolSpeedFraction = 0.2f;
        healt health;
        Vector3 enemyLocations;
        int CurrentWayPointIndex = 0;
        float timeSinceArriaveWayPoint;
        float timeSinceLastSawPlayer;
        mover mover1;
        void Start()
        {
            player = GameObject.FindWithTag("Player");
            fighter=GetComponent<Fighter>();
            health = GetComponent<healt>();
            mover1 = GetComponent<mover>();
            enemyLocations = transform.position;
        }

       
        void Update()
        {

            if (health.IsDead())
            {
                return;
            }

            if (DistanceToPlayer() < chaseDistance && fighter.canAttack(player))
            {
                timeSinceLastSawPlayer = 0;
                fighter.attack(player);
                
            }
            else if (timeSinceLastSawPlayer < suspicionTime)
            {
                GetComponent<actionScheduler>().cancelCurrentAction();
            }

            else
            {
                Vector3 nextPosition = enemyLocations;
                if (patrolPath != null)
                {
                    if (atWaypoint())
                    {
                        timeSinceArriaveWayPoint = 0;
                        CycleWayPoint();
                    }
                    nextPosition = GetNextWayPoint();
                }

                if (timeSinceArriaveWayPoint>wayPointLifeTime)
                {
                    mover1.StartMoveAction(nextPosition, patrolSpeedFraction);
                }
                
            }

            timeSinceLastSawPlayer += Time.deltaTime;
            timeSinceArriaveWayPoint += Time.deltaTime;


        }

        private Vector3 GetNextWayPoint()
        {
            return patrolPath.GetWayPointPosition(CurrentWayPointIndex);
        }

        private void CycleWayPoint()
        {
            CurrentWayPointIndex = patrolPath.getNextIndex(CurrentWayPointIndex);
        }

        private bool atWaypoint()
        {
            float distanceWayPoint = Vector3.Distance(transform.position, GetNextWayPoint());
            return distanceWayPoint < wayPointTolerance;
        }

        private float DistanceToPlayer()
        {
            return Vector3.Distance(player.transform.position, transform.position);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,chaseDistance);
        }
        

    }
}

