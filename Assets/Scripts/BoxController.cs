using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    // Kutunun ba�lang�� ve biti� noktalar�n� temsil eden GameObject'ler
    public GameObject startPoint;
    public GameObject endPoint;

    // Kutunun hareket y�n�n� belirten de�i�ken
    bool goingRight;

    // Hareket h�z�
    public float speed = 1f;

    // Hedefe yak�nl��� belirleyen tolerans de�eri
    public float tolerance = 0.01f;

    void Update()
    {
        // E�er kutu sa�a (endPoint'e) gitmiyorsa
        if (!goingRight)
        {
            // Kutuyu endPoint'e do�ru hareket ettir
            transform.position = Vector2.MoveTowards(transform.position, endPoint.transform.position, speed * Time.deltaTime);

            // E�er kutu endPoint'e yeterince yakla�t�ysa y�n� de�i�tir
            if (Vector2.Distance(transform.position, endPoint.transform.position) < tolerance)
            {
                goingRight = true;
            }
        }
        else
        {
            // Kutuyu startPoint'e do�ru hareket ettir
            transform.position = Vector2.MoveTowards(transform.position, startPoint.transform.position, speed * Time.deltaTime);

            // E�er kutu startPoint'e yeterince yakla�t�ysa y�n� de�i�tir
            if (Vector2.Distance(transform.position, startPoint.transform.position) < tolerance)
            {
                goingRight = false;
            }
        }
    }
}
