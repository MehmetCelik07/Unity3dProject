using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.combat
{
    public class WeaponPickUp : MonoBehaviour
    {
        [SerializeField] Weapon weapon = null;

        private void OnTriggerEnter(Collider other)
        {
            print("temas!!");
            if (other.gameObject.tag == "Player")
            {
                other.GetComponent<Fighter>().spawnWeapon(weapon);
                Destroy(gameObject);
            }
        }
    }
}


