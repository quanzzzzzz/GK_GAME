using UnityEngine;

public class PlayerHealth : Health  // Kế thừa Health
{
    protected override void Die()  // Override để tùy chỉnh
    {
        base.Die();  // Gọi Die() của Health (explosion + destroy)
        Debug.Log("🚀 PLAYER DIED! Game Over!");  // Custom: Log hoặc UI Game Over
        // Sau: Time.timeScale = 0; (dừng game)
    }
}