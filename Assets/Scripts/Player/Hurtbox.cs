using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public int damageTaken = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyHitbox"))
        {
            Debug.Log("Jugador recibe daño");
            // player.TakeDamage(damageTaken);
        }
    }
}
