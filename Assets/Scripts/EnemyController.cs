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
        // �arp��ma oldu�unda Player tag'ini kontrol et
        if (collision.CompareTag("Player"))
        {
            // E�er oyuncu t�m anahtarlar� toplad�ysa
            if (playerController.keyCount == playerController.totalKey)
            {
                // Prenses prensine do�ru ko�maya ba�lar
                princessController.runToPrince = true;
                Debug.Log("Tebrikler");

                // D��man� yok et ve oyuncunun hareket kabiliyetini s�f�rla
                Destroy(gameObject);
                playerController.speed = 0;
                playerController.jumpForce = 0;
            }
            else
            {
                // Oyuncu kaybederse fail paneli a� ve oyunu durdur
                playerController.failPanel.SetActive(true);
                Time.timeScale = 0;
                Debug.Log("Kaybettin");
            }
        }
    }
}
