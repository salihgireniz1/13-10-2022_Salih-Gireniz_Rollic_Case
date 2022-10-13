public class FailedState : GameState
{
    public override void EnterState(GameStateMachine machine)
    {
        // Stop player movement.
        Player.Instance.SwitchPlayerState(Player.Instance.stateMachine.frozenState);
        // Activate UI win features.
        UIManager.Instance.SwitchPanel(UIManager.Instance.retryPanel);
    }

    public override void UpdateState(GameStateMachine machine)
    {

    }
}
