using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Cinamatics
{
    public class fakePlayableDiracter : MonoBehaviour
    {

        void Start()
        {
            Invoke("onFinish", 3f);
        }
        void onFinish()
        {

        }

    }
}

