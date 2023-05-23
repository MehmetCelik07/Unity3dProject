using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using RPG.controller;


namespace RPG.Cinamatics
{
    public class CinamaticsControlRevormer : MonoBehaviour
    {

        GameObject player;
        void Start()
        {
            player = GameObject.FindWithTag("Player");
            GetComponent<PlayableDirector>().played += disAbleControl;
            GetComponent<PlayableDirector>().stopped += enableControl;
            
        }

        void enableControl(PlayableDirector pd)
        {
            player.GetComponent<PlayerController>().enabled = true;
        }

        void disAbleControl(PlayableDirector pd)
        {
            player.GetComponent<PlayerController>().enabled = false;
        }


 
    }

}
