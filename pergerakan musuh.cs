using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float rotateSpeed = 100f; // Kecepatan putaran musuh
    public Transform startPoint; // Titik awal untuk me-reset posisi player
    public float maxDistance = 5f; // Jarak maksimal pergerakan musuh dari posisi awal

    private Vector2 initialPosition; // Posisi awal musuh

    private void Start()
    {
        initialPosition = transform.position; // Simpan posisi awal musuh
    }

    private void FixedUpdate()
    {
        // Putar musuh dengan kecepatan rotateSpeed
        transform.Rotate(0f, 0f, rotateSpeed * Time.fixedDeltaTime);

        // Hitung jarak antara posisi awal musuh dan posisi saat ini
        float distance = Vector2.Distance(transform.position, initialPosition);

        // Jika jarak melebihi batas, pindahkan musuh ke posisi awal
        if (distance > maxDistance)
        {
            transform.position = initialPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reset posisi player ke startPoint
            collision.gameObject.transform.position = startPoint.position;
        }
    }
}
