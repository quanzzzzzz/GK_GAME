using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform player;
    public GameObject bulletPrefab;

    public Transform firePoint;
    public float shootingInterval = 1f;
    public float bulletSpeed = 10f;

    float lastShot;

    void Update()
    {
        if (player == null || bulletPrefab == null || firePoint == null) return;

        AimFirePointToPlayer();

        if (Time.time - lastShot >= shootingInterval)
        {
            Shoot();
            lastShot = Time.time;
        }
    }

    void AimFirePointToPlayer()
    {
        Vector2 dir = (player.position - firePoint.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    void Shoot()
    {
        GameObject b = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        var rb = b.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = (Vector2)firePoint.right * bulletSpeed;
        }
    }
}
