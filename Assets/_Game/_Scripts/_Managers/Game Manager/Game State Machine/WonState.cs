public class WonState : GameState
{
    public override void EnterState(GameStateMachine machine)
    {
        LevelManager.Instance.LoadNewLevel();
        // Stop player movement.
        Player.Instance.SwitchPlayerState(Player.Instance.stateMachine.frozenState);
        // Activate UI win features.
        UIManager.Instance.SwitchPanel(UIManager.Instance.nextLevelPanel);
    }

    public override void UpdateState(GameStateMachine machine)
    {

    }
}
