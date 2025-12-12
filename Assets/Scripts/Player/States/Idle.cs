using UnityEngine;

public class Idle : MonoBehaviour
{
    private PlayerStateMachine player;

    public Idle(PlayerStateMachine player) 
    { 
        this.player = player;
    }

    public void Enter()
    {
        player.animator.Play("Idle");
    }
}
