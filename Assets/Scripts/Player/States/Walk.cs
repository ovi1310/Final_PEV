using UnityEngine;

public class Walk : IState
{
    private PlayerStateMachine player;

    public Walk(PlayerStateMachine player) { this.player = player; }

    public void Enter()
    {
        player.animator.Play("Walk");
    }

    public void Execute()
    {
        if (Mathf.Abs(player.moveInput.x) < 0.1f)
            player.ChangeState(PlayerState.Idle);

        if (player.jumpPressed && player.isGrounded)
        {
            player.ChangeState(PlayerState.Idle);
            player.jumpPressed = false;
        }
    }

    public void Exit() { }
}

