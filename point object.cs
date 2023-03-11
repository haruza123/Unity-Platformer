using UnityEngine;

public class Ring : MonoBehaviour
{
    public int points = 10; // jumlah poin yang akan ditambahkan saat objek diambil
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // tambahkan poin ke skor karakter
            ScoreManager.instance.AddPoints(points);
            
            // hapus objek cincin dari scene
            Destroy(gameObject);
        }
    }
}
