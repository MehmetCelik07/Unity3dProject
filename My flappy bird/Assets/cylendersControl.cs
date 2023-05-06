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

    // Cylinder prefabýný atanacak
    public GameObject cylinderPrefab;

    // Cylinder oluþturulacak pozisyon
    public Vector3 position1 = new Vector3(12,5,0);
    public Vector3 position2 = new Vector3(12, -2.6f, 0);

    public void CreateRandomCylinder()
    {
        // Y skalasýný rastgele belirlemek için Random.Range() kullanýlýr
        float yScale1 = Random.Range(2f, 3f);
        float yScale2 = Random.Range(2f, 3f);

        // Cylinder prefabýný Instantiate() kullanarak oluþturulur
        GameObject newCylinder1 = Instantiate(cylinderPrefab, position1, Quaternion.identity);
        GameObject newCylinder2 = Instantiate(cylinderPrefab, position2, Quaternion.identity);

        // Y skalasý ayarlanýr
        newCylinder1.transform.localScale = new Vector3(1f, yScale1, 1f);
        newCylinder2.transform.localScale = new Vector3(1f, yScale2, 1f);
    }
    public float speed = 2f; // cylinder'larýn hareket hýzý

    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0); // cylinder'larý hareket ettirir
        if (transform.position.x < -10f) // cylinder'lar belirli bir noktaya geldiðinde yeniden konumlandýrýlýr
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
