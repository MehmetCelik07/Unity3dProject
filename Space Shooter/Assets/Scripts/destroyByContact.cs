using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyByContact : MonoBehaviour
{
    public GameObject Explosion,PlayerExplosion;
    public gameController gameControl;
    public GameObject shieldObje;
    private void Start()
    {
        gameControl = GameObject.FindWithTag("GameController").GetComponent<gameController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boundary")
        {
            return;
        }
        Instantiate(Explosion,transform.position,transform.rotation);
        if (other.tag=="Player")
        {       
            Instantiate(PlayerExplosion, other.transform.position, other.transform.rotation);
            gameControl.playerLose();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameControl.GetComponent<gameController>().PuanUpdate();

    }
  


}
