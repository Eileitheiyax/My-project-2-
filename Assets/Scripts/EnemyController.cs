using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Health health; 
    public int damageAmount = 20;

    private GameManager gameManager;

    void Start()
    {
        health = GetComponent<Health>();
        gameManager = GameManager.Instance;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            health.TakeDamage(damageAmount); 
            Destroy(other.gameObject); 

            if (health.currentHealth <= 0)
            {
                Die(); 
            }
        }
    }

    void Die()
    {
        gameManager.scoreManager.AddScore(10);
        gameManager.audioManager.PlayOneShotAudio(1);
        Destroy(gameObject); 
    }
}
