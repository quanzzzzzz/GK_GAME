using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float flySpeed = 10f;  // Tốc độ bay (Inspector chỉnh)
    public int damage = 1;        // Sát thương (Part 4)

    private Rigidbody2D rb;       // Physics

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Lấy Rigidbody (phải add trước)
        rb.velocity = Vector2.up * flySpeed;  // Bay lên một lần (không Update())
    }

    private void OnTriggerEnter2D(Collider2D collision)  // Collision detect (Part 3-4)
    {
        // Damage Health system (Part 4 trang 11)
        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
            Destroy(gameObject);  // Destroy đạn (không xuyên qua)
            return;
        }
    }

    // Tự hủy nếu bay ra màn hình (tùy chọn, tránh leak)
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}