using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyHealth health;  // Link EnemyHealth của chính enemy
    public int damage = 1;      // Damage cho player

    private void OnTriggerEnter2D(Collider2D collision)  // SỬA: Collider2D (PDF dùng Collision2D sai)
    {
        var playerHealth = collision.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);     // Damage player
            health.TakeDamage(1000);             // Enemy self-destruct (HP=1 → die ngay)
        }
    }
}