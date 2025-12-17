using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyHurtbox"))
        {
            Debug.Log("Enemigo golpeado");
            // other.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
        PlayerHealth health = other.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}

