using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomRatoter : MonoBehaviour
{
    Rigidbody rb;
    public int speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere*speed;
    }

   
}
