using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    // Kutunun baþlangýç ve bitiþ noktalarýný temsil eden GameObject'ler
    public GameObject startPoint;
    public GameObject endPoint;

    // Kutunun hareket yönünü belirten deðiþken
    bool goingRight;

    // Hareket hýzý
    public float speed = 1f;

    // Hedefe yakýnlýðý belirleyen tolerans deðeri
    public float tolerance = 0.01f;

    void Update()
    {
        // Eðer kutu saða (endPoint'e) gitmiyorsa
        if (!goingRight)
        {
            // Kutuyu endPoint'e doðru hareket ettir
            transform.position = Vector2.MoveTowards(transform.position, endPoint.transform.position, speed * Time.deltaTime);

            // Eðer kutu endPoint'e yeterince yaklaþtýysa yönü deðiþtir
            if (Vector2.Distance(transform.position, endPoint.transform.position) < tolerance)
            {
                goingRight = true;
            }
        }
        else
        {
            // Kutuyu startPoint'e doðru hareket ettir
            transform.position = Vector2.MoveTowards(transform.position, startPoint.transform.position, speed * Time.deltaTime);

            // Eðer kutu startPoint'e yeterince yaklaþtýysa yönü deðiþtir
            if (Vector2.Distance(transform.position, startPoint.transform.position) < tolerance)
            {
                goingRight = false;
            }
        }
    }
}
