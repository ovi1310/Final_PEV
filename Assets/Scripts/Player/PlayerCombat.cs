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
}
