using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylendersControl : MonoBehaviour
{

    
    public gameController kontrol;

    private void Start()
    {
        kontrol = GameObject.FindWithTag("GameController").GetComponent<gameController>();
    }

    // Cylinder prefab�n� atanacak
    public GameObject cylinderPrefab;

    // Cylinder olu�turulacak pozisyon
    public Vector3 position1 = new Vector3(12,5,0);
    public Vector3 position2 = new Vector3(12, -2.6f, 0);

    public void CreateRandomCylinder()
    {
        // Y skalas�n� rastgele belirlemek i�in Random.Range() kullan�l�r
        float yScale1 = Random.Range(2f, 3f);
        float yScale2 = Random.Range(2f, 3f);

        // Cylinder prefab�n� Instantiate() kullanarak olu�turulur
        GameObject newCylinder1 = Instantiate(cylinderPrefab, position1, Quaternion.identity);
        GameObject newCylinder2 = Instantiate(cylinderPrefab, position2, Quaternion.identity);

        // Y skalas� ayarlan�r
        newCylinder1.transform.localScale = new Vector3(1f, yScale1, 1f);
        newCylinder2.transform.localScale = new Vector3(1f, yScale2, 1f);
    }
    public float speed = 2f; // cylinder'lar�n hareket h�z�

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0); // cylinder'lar� hareket ettirir
        if (transform.position.x < -10f) // cylinder'lar belirli bir noktaya geldi�inde yeniden konumland�r�l�r
        {
            Destroy(cylinderPrefab);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Ground")
        {
            Destroy(other.gameObject);
            kontrol.gameOver();
        }

    }
}
