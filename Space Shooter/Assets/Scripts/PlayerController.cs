using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    Rigidbody physic;
    [SerializeField] int speed;
    public Boundary boundary;
    public GameObject shots;
    public GameObject shotSpawn;
    float nextFire;
    [SerializeField] float fireRate;
     void Start()
    {
        physic = GetComponent<Rigidbody>();
    }

     void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shots, shotSpawn.transform.position, shotSpawn.transform.rotation);

        }
        
    }
    void FixedUpdate()
    {
        //Gemiyi hareket ettirmek için klasik yol.
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
        physic.velocity = movement*speed;


        //**** gemiyi istediðim pozisyon deðerlerinde tutmak için gerekli kod ****
        Vector3 position = new Vector3(Mathf.Clamp(physic.position.x,boundary.xMin,boundary.xMax),0,
            Mathf.Clamp(physic.position.z,boundary.zMin,boundary.zMax));
            physic.position = position;
        //********************

        //rotasyon ile oynayarak hareket hissi verme

        physic.rotation = Quaternion.Euler(physic.velocity.z*2,0,physic.velocity.x*-5);
    }
}
