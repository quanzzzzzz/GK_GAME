using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private GameObject winPanel;
    protected override void Die()
    {
        base.Die();
        Debug.Log("Enemy died");

        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
        else
        {
        }
    }
}