using UnityEngine;

public enum PlayerState
{
    Idle,
    Walk,
    Jump,
    Fall,
    Crouch,
    AttackMelee,
    AttackRanged,
    Interact,
    TakingDamage
}

public class PlayerAttackRangedState : PlayerState
{
    public PlayerAttackRangedState(PlayerStateMachine sm) : base(sm) { }

    public override void Enter()
    {
        Vector3 dir = stateMachine.transform.right;

        stateMachine.Combat.RangedAttack(dir);
        stateMachine.Input.ConsumeRanged();

        stateMachine.ChangeState(PlayerStateType.Idle);
    }
}
