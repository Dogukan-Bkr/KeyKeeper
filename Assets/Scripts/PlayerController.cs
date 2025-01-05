using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Fail paneli referans�
    public GameObject failPanel;

    // Rigidbody2D bile�eni
    Rigidbody2D rb;

    // Hareket i�in X ekseni inputu
    float x;

    // Oyuncunun h�z� ve z�plama kuvveti
    public int speed;
    public int jumpForce;

    // Anahtar say�s� g�stergesi
    public Text keyCounter;

    // Toplam anahtar say�s� ve toplanan anahtar say�s�
    public int totalKey = 4;
    public int keyCount = 0;

    // Oyuncunun yerde olup olmad���n� belirten de�i�ken
    bool isGround = true;

    void Start()
    {
        // Rigidbody2D bile�enini al
        rb = GetComponent<Rigidbody2D>();

        // �lk anahtar durumu ekran�na yans�t�l�r
        TakenKey();
    }

    void Update()
    {
        // Z�plama i�lemi Update fonksiyonu ile yap�lacak
        if (Input.GetKeyDown(KeyCode.Space) && isGround) { PlayerJump(); }
    }

    // Hareket i�lemleri art�k FixedUpdate i�erisinde yap�lacak
    void FixedUpdate()
    {
        // Yatay hareketin yap�lmas�
        x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(x * speed, rb.velocity.y);  // Yaln�zca X ekseninde h�z, Y ekseninde mevcut h�z korunur
                                                              // Y�n� kontrol et ve sprite'� do�ru y�ne d�nd�r
        if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false; // Sa� hareket ediyorsa sprite sa�a bakmal�
        }
        else if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true; // Sol hareket ediyorsa sprite sola bakmal�
        }
    }

    // Z�plama fonksiyonu
    void PlayerJump()
    {
        rb.velocity += new Vector2(0, jumpForce);  // Yaln�zca Y ekseninde z�plama kuvveti ekliyoruz
        isGround = false;
    }

    // Anahtar say�s�n� ekran�na yans�t
    void TakenKey()
    {
        keyCounter.text = keyCount + " / " + totalKey; // Anahtar durumu ekran�
    }

    // Yere �arpan oyuncu
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

    // Trigger alan�na giren nesneyle etkile�im
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Anahtar toplama durumu
        if (collision.CompareTag("Fruit"))
        {
            keyCount++;
            Destroy(collision.gameObject);
            TakenKey();
        }
        // Engellere �arpma durumu
        else if (collision.CompareTag("Obstacle"))
        {
            // Fail panelini aktif et ve oyunu durdur
            failPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Yeniden ba�latma butonu
    public void TryAgainButton()
    {
        SceneManager.LoadScene(0); // �lk sahneyi yeniden y�kle
    }

    // Oyundan ��kma butonu
    public void ExitButton()
    {
        Application.Quit(); // Uygulamay� kapat
    }
}
