using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Fail paneli referansý
    public GameObject failPanel;

    // Rigidbody2D bileþeni
    Rigidbody2D rb;

    // Hareket için X ekseni inputu
    float x;

    // Oyuncunun hýzý ve zýplama kuvveti
    public int speed;
    public int jumpForce;

    // Anahtar sayýsý göstergesi
    public Text keyCounter;

    // Toplam anahtar sayýsý ve toplanan anahtar sayýsý
    public int totalKey = 4;
    public int keyCount = 0;

    // Oyuncunun yerde olup olmadýðýný belirten deðiþken
    bool isGround = true;

    void Start()
    {
        // Rigidbody2D bileþenini al
        rb = GetComponent<Rigidbody2D>();

        // Ýlk anahtar durumu ekranýna yansýtýlýr
        TakenKey();
    }

    void Update()
    {
        // Zýplama iþlemi Update fonksiyonu ile yapýlacak
        if (Input.GetKeyDown(KeyCode.Space) && isGround) { PlayerJump(); }
    }

    // Hareket iþlemleri artýk FixedUpdate içerisinde yapýlacak
    void FixedUpdate()
    {
        // Yatay hareketin yapýlmasý
        x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);  // Yalnýzca X ekseninde hýz, Y ekseninde mevcut hýz korunur
                                                              // Yönü kontrol et ve sprite'ý doðru yöne döndür
        if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false; // Sað hareket ediyorsa sprite saða bakmalý
        }
        else if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true; // Sol hareket ediyorsa sprite sola bakmalý
        }
    }

    // Zýplama fonksiyonu
    void PlayerJump()
    {
        rb.velocity += new Vector2(0, jumpForce);  // Yalnýzca Y ekseninde zýplama kuvveti ekliyoruz
        isGround = false;
    }

    // Anahtar sayýsýný ekranýna yansýt
    void TakenKey()
    {
        keyCounter.text = keyCount + " / " + totalKey; // Anahtar durumu ekraný
    }

    // Yere çarpan oyuncu
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

    // Trigger alanýna giren nesneyle etkileþim
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Anahtar toplama durumu
        if (collision.CompareTag("Fruit"))
        {
            keyCount++;
            Destroy(collision.gameObject);
            TakenKey();
        }
        // Engellere çarpma durumu
        else if (collision.CompareTag("Obstacle"))
        {
            // Fail panelini aktif et ve oyunu durdur
            failPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Yeniden baþlatma butonu
    public void TryAgainButton()
    {
        SceneManager.LoadScene(0); // Ýlk sahneyi yeniden yükle
    }

    // Oyundan çýkma butonu
    public void ExitButton()
    {
        Application.Quit(); // Uygulamayý kapat
    }
}
