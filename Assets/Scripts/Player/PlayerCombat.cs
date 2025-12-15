using UnityEngine;

[RequireComponent(typeof(PlayerInputHandler))]
public class PlayerCombat : MonoBehaviour
{
    private PlayerInputHandler input;

    void Start()
    {
        input = GetComponent<PlayerInputHandler>();
    }

    void Update()
    {
        if (input.AttackMeleePressed)
        {
            Debug.Log("Ataque melee");
            input.ConsumeMelee();
        }

        if (input.AttackRangedPressed)
        {
            Debug.Log("Ataque ranged");
            input.ConsumeRanged();
        }
    }

    [Header("Ranged Attack")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float rangedCooldown = 0.5f;

    private float lastRangedTime;

    public bool CanRangedAttack()
    {
        return Time.time >= lastRangedTime + rangedCooldown;
    }

    public void RangedAttack(Vector3 direction)
    {
        if (!CanRangedAttack()) return;

        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        proj.GetComponent<Projectile>().SetDirection(direction);

        lastRangedTime = Time.time;
    }
}
