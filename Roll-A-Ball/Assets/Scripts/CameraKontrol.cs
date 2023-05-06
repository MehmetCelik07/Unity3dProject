using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraKontrol : MonoBehaviour
{
    public GameObject top;
    Vector3 aradaKiFark;
    void Start()
    {
        aradaKiFark = transform.position - top.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = top.transform.position + aradaKiFark;
    }
}
