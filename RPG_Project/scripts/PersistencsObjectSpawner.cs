using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.core
{
    public class PersistencsObjectSpawner : MonoBehaviour
    {
        [SerializeField] GameObject persistensGameobject;
        static bool hasSpawned = false;
        private void Awake()
        {
            if (hasSpawned) return;
           
            spawnPersistensObjects();

            hasSpawned = true;

        }
        void spawnPersistensObjects()
        {
            GameObject persistensObject = Instantiate(persistensGameobject);
            DontDestroyOnLoad(persistensObject);
        }
    }

}
