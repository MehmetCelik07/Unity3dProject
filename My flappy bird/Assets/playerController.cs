using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    public float jumpForce; // karakterin zýplama kuvveti
    Rigidbody rb; // karakterin rigidbody bileþeni

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // rigidbody bileþenini alýr
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // space tuþuna basýlýrsa
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // karaktere yukarý doðru bir kuvvet uygulanýr
        }
    }
}
