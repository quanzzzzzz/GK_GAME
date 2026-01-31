using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject explosionPrefab;  // Để dùng sau (trang 24)

    private void OnTriggerEnter2D(Collider2D collision)  // SỬA: Collider2D!
    {
        // CHECK TAG để chỉ die khi va Bullet (phân biệt friend/foe, trang 15)
        if (collision.CompareTag("Bullet"))
        {
            Die();
        }
    }

    private void Die()
    {
        // Thêm explosion sau (nếu có prefab)
        if (explosionPrefab != null)
        {
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(explosion, 1f);  // Tự destroy sau 1s
        }
        Destroy(gameObject);  // Die enemy
    }
}
