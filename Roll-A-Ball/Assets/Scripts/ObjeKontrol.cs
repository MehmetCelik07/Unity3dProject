using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjeKontrol : MonoBehaviour
{
    public float hiz;
    public Vector3 vector;
    void Start()
    {
        
    }

   
    void Update()
    {
        transform.Rotate(vector*hiz);
    }
}
