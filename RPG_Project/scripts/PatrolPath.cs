using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.controller
{
    public class PatrolPath : MonoBehaviour
    {
        const float wayPointsRadius = 0.4f;
        private void OnDrawGizmos()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                int j = getNextIndex(i);
                Gizmos.DrawSphere(GetWayPointPosition(i), wayPointsRadius);
                Gizmos.DrawLine(GetWayPointPosition(i), GetWayPointPosition(j));
            }
        }

        public int getNextIndex(int i)
        {
            if (i+1 == transform.childCount)
            {
                return 0;
            }
            return i + 1;
        }

        public Vector3 GetWayPointPosition(int i)
        {
            return transform.GetChild(i).position;
        }
    }

}
