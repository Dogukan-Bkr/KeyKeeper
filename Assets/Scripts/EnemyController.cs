using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Player ve Princess kontrol scriptlerine referanslar
    public PlayerController playerController;
    public PrincessController princessController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Çarpýþma olduðunda Player tag'ini kontrol et
        if (collision.CompareTag("Player"))
        {
            // Eðer oyuncu tüm anahtarlarý topladýysa
            if (playerController.keyCount == playerController.totalKey)
            {
                // Prenses prensine doðru koþmaya baþlar
                princessController.runToPrince = true;
                Debug.Log("Tebrikler");

                // Düþmaný yok et ve oyuncunun hareket kabiliyetini sýfýrla
                Destroy(gameObject);
                playerController.speed = 0;
                playerController.jumpForce = 0;
            }
            else
            {
                // Oyuncu kaybederse fail paneli aç ve oyunu durdur
                playerController.failPanel.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("Kaybettin");
            }
        }
    }
}
