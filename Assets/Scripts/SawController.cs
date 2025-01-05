using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    // Testerenin baþlangýç ve bitiþ noktalarýný temsil eden GameObject'ler
    public GameObject startPoint;
    public GameObject endPoint;

    // Testerenin hareket yönünü belirten deðiþken
    bool goingRight;

    // Testerenin hareket hýzý
    public float speed = 1f;

    // Hedefe olan mesafeyi belirlemek için tolerans deðeri
    public float tolerance = 0.01f;

    void Update()
    {
        // Eðer testere saða (endPoint'e) gitmiyorsa
        if (!goingRight)
        {
            // Testereyi endPoint'e doðru hareket ettir
            transform.position = Vector2.MoveTowards(transform.position, endPoint.transform.position, speed * Time.deltaTime);

            // Testere endPoint'e yeterince yaklaþtýðýnda yön deðiþtir
            if (Vector2.Distance(transform.position, endPoint.transform.position) < tolerance)
            {
                goingRight = true;
            }
        }
        else
        {
            // Testereyi startPoint'e doðru hareket ettir
            transform.position = Vector2.MoveTowards(transform.position, startPoint.transform.position, speed * Time.deltaTime);

            // Testere startPoint'e yeterince yaklaþtýðýnda yön deðiþtir
            if (Vector2.Distance(transform.position, startPoint.transform.position) < tolerance)
            {
                goingRight = false;
            }
        }
    }
}
