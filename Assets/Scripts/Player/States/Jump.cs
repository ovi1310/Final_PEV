using UnityEngine;

public class Jump : IState
{
    private PlayerStateMachine player;

    public Jump(PlayerStateMachine player) { this.player = player; }

    public void Enter()
    {
        player.animator.Play("Jump");
        player.rb.linearVelocity = new Vector2(player.rb.linearVelocity.x, player.jumpForce);
    }

    public void Execute()
    {
        if (player.rb.linearVelocity.y < -0.1f)
            player.ChangeState(PlayerState.Fall);
    }

    public void Exit() { }
}
