using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    // Testerenin ba�lang�� ve biti� noktalar�n� temsil eden GameObject'ler
    public GameObject startPoint;
    public GameObject endPoint;

    // Testerenin hareket y�n�n� belirten de�i�ken
    bool goingRight;

    // Testerenin hareket h�z�
    public float speed = 1f;

    // Hedefe olan mesafeyi belirlemek i�in tolerans de�eri
    public float tolerance = 0.01f;

    void Update()
    {
        // E�er testere sa�a (endPoint'e) gitmiyorsa
        if (!goingRight)
        {
            // Testereyi endPoint'e do�ru hareket ettir
            transform.position = Vector2.MoveTowards(transform.position, endPoint.transform.position, speed * Time.deltaTime);

            // Testere endPoint'e yeterince yakla�t���nda y�n de�i�tir
            if (Vector2.Distance(transform.position, endPoint.transform.position) < tolerance)
            {
                goingRight = true;
            }
        }
        else
        {
            // Testereyi startPoint'e do�ru hareket ettir
            transform.position = Vector2.MoveTowards(transform.position, startPoint.transform.position, speed * Time.deltaTime);

            // Testere startPoint'e yeterince yakla�t���nda y�n de�i�tir
            if (Vector2.Distance(transform.position, startPoint.transform.position) < tolerance)
            {
                goingRight = false;
            }
        }
    }
}
