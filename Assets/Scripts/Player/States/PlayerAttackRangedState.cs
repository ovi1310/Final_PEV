using UnityEngine;

void StateAttackRanged()
{
    // Dirección del disparo
    Vector3 dir = transform.right; // transform pertenece a MonoBehaviour

    // Ejecutar ataque
    if (combat != null)
        PlayerCombat.RangedAttack(dir);

    // Resetear input
    if (inputHandler != null)
        inputHandler.ConsumeRanged();

    // Volver a Idle
    ChangeState(PlayerState.Idle);
}


