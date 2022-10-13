public class CheckpointState : GameState
{
    public override void EnterState(GameStateMachine machine)
    {
        // Make player idle.
        Player.Instance.SwitchPlayerState(Player.Instance.stateMachine.idleState);
    }

    public override void UpdateState(GameStateMachine machine)
    {

    }
}
