using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyerCube : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
