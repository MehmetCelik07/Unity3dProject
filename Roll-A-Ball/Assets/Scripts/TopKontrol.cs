using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopKontrol : MonoBehaviour
{
    public int hiz;
    Rigidbody top;
    public int puan;
    public Text puanTxt;
    public GameObject OyunSonuObje;
    
    void Start()
    {
        top = GetComponent<Rigidbody>();
    }

  
    void FixedUpdate()
    {
       float yatay= Input.GetAxisRaw("Horizontal");
       float dikey =Input.GetAxisRaw("Vertical");
       Vector3 vector = new Vector3(yatay, 0, dikey);

        top.AddForce(vector*hiz);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Destroy(other.gameObject);
        other.gameObject.SetActive(false);
        puan++;
        puanTxt.text="Puan: " + puan;
        if (puan==8)
        {
            OyunSonuObje.SetActive(true);
        }
    }

    public void oyunSonuBtns(int BtnNumber)
    {
        if (BtnNumber==0)
        {
            SceneManager.LoadScene("MainScene");
        }
        else if (BtnNumber==1)
        {
            Application.Quit();
        }
    }


}
