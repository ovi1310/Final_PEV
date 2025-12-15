//using UnityEngine;

//// Script opcional para manejar el ataque a distancia como componente separado
//// Funciona con PlayerStateMachine existente
//public class PlayerAttackRangedState : MonoBehaviour
//{
//    private PlayerStateMachine stateMachine;

//    private void Awake()
//    {
//        // Obtiene la referencia al PlayerStateMachine del mismo GameObject
//        stateMachine = GetComponent<PlayerStateMachine>();
//    }

//    // Llamar este método para ejecutar un ataque a distancia
//    public void Enter()
//    {
//        if (stateMachine == null) return;

//        // Dirección del disparo según hacia dónde mira el jugador
//        Vector3 dir = stateMachine.transform.localScale.x > 0 ? Vector3.right : Vector3.left;

//        // Ejecutar ataque mediante PlayerCombat
//        if (stateMachine.combat != null)
//        {
//            stateMachine.combat.RangedAttack(dir);
//        }

//        // Consumir input para evitar disparos múltiples
//        if (stateMachine.inputHandler != null)
//        {
//            stateMachine.inputHandler.ConsumeRanged();
//        }

//        // Volver automáticamente al estado Idle
//        stateMachine.ChangeState(PlayerState.Idle);
//    }
//}
