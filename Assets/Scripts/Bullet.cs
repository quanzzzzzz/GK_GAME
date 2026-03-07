using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speed = 20f;
    public float flySpeed;
    public int damage;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        Destroy(gameObject, 3f); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<EnemyHealth>();
        if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        Destroy(gameObject);
    }
}