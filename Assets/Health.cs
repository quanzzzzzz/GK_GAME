using UnityEngine;

public class Health : MonoBehaviour  // Base class kế thừa MonoBehaviour
{
    [Header("Health Settings")]  // Nhóm trong Inspector
    public GameObject explosionPrefab;  // Prefab explosion (trang 20-25 Part 3)
    public int defaultHealthPoint = 1;  // HP mặc định (trang 9)

    private int healthPoint;  // HP hiện tại (private để bảo mật)

    private void Start()
    {
        healthPoint = defaultHealthPoint;  // Khởi tạo HP khi game start
    }

    // Public method: Nhận sát thương từ đạn/va chạm (gọi từ Bullet.cs hoặc EnemyAttack.cs)
    public void TakeDamage(int damage)
    {
        if (healthPoint <= 0) return;  // Đã chết thì ignore

        healthPoint -= damage;  // Trừ HP
        Debug.Log(gameObject.name + " nhận " + damage + " damage. HP còn: " + healthPoint);

        if (healthPoint <= 0)
        {
            Die();  // Chết nếu HP <= 0
        }
    }

    // Protected virtual: Chết (có thể override ở class con)
    protected virtual void Die()
    {
        // Hiển thị explosion (trang 8 PDF)
        if (explosionPrefab != null)
        {
            var explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(explosion, 1f);  // Tự hủy explosion sau 1 giây
        }

        Destroy(gameObject);  // Hủy object (Player/Enemy)
    }
}