using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessController : MonoBehaviour
{
    // Prens karakterine ula�mak i�in referanslar
    public GameObject player;
    public GameObject successPanel;

    // Prensesin prense do�ru ko�ma durumunu kontrol eden de�i�ken
    public bool runToPrince;

    void Start()
    {
        // Oyun h�z�n� normal seviyeye getir
        Time.timeScale = 1f;
    }

    void Update()
    {
        // E�er runToPrince true ise prense do�ru ko�ma fonksiyonunu �a��r
        if (runToPrince) { RunToPrince(); }
    }

    public void RunToPrince()
    {
        // Prensesi, oyuncunun pozisyonuna do�ru hareket ettir
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �arp��ma ger�ekle�ti�inde ba�ar� panelini g�ster ve oyunu durdur
        successPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
