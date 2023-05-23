using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.core
{
    public class fallowCamera : MonoBehaviour
    {
        [SerializeField] Transform player;
        void LateUpdate()
        {
            transform.position = player.position;
        }
       
    }
}

