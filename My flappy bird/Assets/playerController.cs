using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerController : MonoBehaviour
{
    public float jumpForce; // karakterin z�plama kuvveti
    Rigidbody rb; // karakterin rigidbody bile�eni

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // rigidbody bile�enini al�r
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // space tu�una bas�l�rsa
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // karaktere yukar� do�ru bir kuvvet uygulan�r
        }
    }
}
