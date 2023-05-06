using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameController : MonoBehaviour
{
    public GameObject cyControl;
    public Text seviyeTxt;
    public GameObject yourPerfectTxt;
    public GameObject gameoverPanel;
    public bool isgameover;
    void Start()
    {
        Screen.SetResolution(900, 600,true);
        StartCoroutine(SpawnCylinder());
        isgameover = false;
    }

    IEnumerator SpawnCylinder()
    {
        for (int i = 0; i < 5; i++)
        {
            cyControl.GetComponent<cylendersControl>().CreateRandomCylinder();
            yield return new WaitForSeconds(8);
        }
        yield return new WaitForSeconds(3);
        seviyeTxt.text = "Seviye 2";

        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(5);
            cyControl.GetComponent<cylendersControl>().CreateRandomCylinder();
        }
        yield return new WaitForSeconds(5);
        seviyeTxt.text = "Seviye 3";

        for (int i = 0; i < 7; i++)
        {
            yield return new WaitForSeconds(3);
            cyControl.GetComponent<cylendersControl>().CreateRandomCylinder();
        }
        yield return new WaitForSeconds(6);
        seviyeTxt.text = "Seviye 4";

        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(1.5f);
            cyControl.GetComponent<cylendersControl>().CreateRandomCylinder();
        }
        yield return new WaitForSeconds(7);
        seviyeTxt.text = "Ýmkansýz!!!";

        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1f);
            cyControl.GetComponent<cylendersControl>().CreateRandomCylinder();
        }
        yield return new WaitForSeconds(5);

        yourPerfectTxt.SetActive(true);


    }

    public void gameOver()
    {
        isgameover = true;
        gameoverPanel.SetActive(true);
    }
    private void Update()
    {
        if (isgameover)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }
        }     
    }


}
