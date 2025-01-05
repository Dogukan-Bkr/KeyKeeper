using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessController : MonoBehaviour
{
    // Prens karakterine ulaþmak için referanslar
    public GameObject player;
    public GameObject successPanel;

    // Prensesin prense doðru koþma durumunu kontrol eden deðiþken
    public bool runToPrince;

    void Start()
    {
        // Oyun hýzýný normal seviyeye getir
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Eðer runToPrince true ise prense doðru koþma fonksiyonunu çaðýr
        if (runToPrince) { RunToPrince(); }
    }

    public void RunToPrince()
    {
        // Prensesi, oyuncunun pozisyonuna doðru hareket ettir
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Çarpýþma gerçekleþtiðinde baþarý panelini göster ve oyunu durdur
        successPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
