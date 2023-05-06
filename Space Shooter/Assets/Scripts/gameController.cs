using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public GameObject hazard;
    public float AstroidCount;
    public float AstroidSpeed;
    public Text PaunTxt;
    int puan;
    int kalanHak;
    public GameObject[] canlar;
    public GameObject player,gameOverPanel;
    public bool oyunBitti;


    IEnumerator spawnValues()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            yield return new WaitForSeconds(3);
            for (int i = 0; i < AstroidCount; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-2.8f, 2.8f), 0, 10);
                Quaternion spawnRot = Quaternion.identity;
                Instantiate(hazard, spawnPos, spawnRot);
                yield return new WaitForSeconds(AstroidSpeed);
            }
            if (oyunBitti)
            {
                break;
            }
        }

    }

    public void PuanUpdate()
    {
        puan+=10;
        PaunTxt.text = "Score: " + puan;

    }

    public void playerLose()
    {
        kalanHak--;
        if (kalanHak>0)
        {
            canlar[kalanHak].SetActive(false);
            Instantiate(player);
        }
        else
        {
            canlar[0].SetActive(false);
            gameOver();

        }
       
    }

    public void gameOver()
    {
        Debug.Log("oyun Bitti!!");
        gameOverPanel.SetActive(true);
        oyunBitti = true;
    }
    void Start()
    {
        Screen.SetResolution(600, 900, true);
        kalanHak = 3;
        oyunBitti = false;
        StartCoroutine(spawnValues());
        
    }
    private void Update()
    {

        if (oyunBitti)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
       
    }
}
