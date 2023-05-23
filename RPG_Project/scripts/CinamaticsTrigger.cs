using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinamatics
{
    public class CinamaticsTrigger : MonoBehaviour
    {
        bool alreadTrigger = false;
        private void OnTriggerEnter(Collider other)
        {
            if (!alreadTrigger && other.gameObject.tag == "Player")
            {
                alreadTrigger = true;
                GetComponent<PlayableDirector>().Play();
                GetComponent<BoxCollider>().enabled = false;
            }
            
        }
    }
}

