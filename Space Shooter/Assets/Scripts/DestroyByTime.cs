using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject,2);
    }
}
