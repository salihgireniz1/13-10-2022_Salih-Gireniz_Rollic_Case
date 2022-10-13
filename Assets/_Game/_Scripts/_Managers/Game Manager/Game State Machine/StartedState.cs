using UnityEngine;

public class StartedState : GameState
{
    public override void EnterState(GameStateMachine machine)
    {
        // Make player going forward.
        Player.Instance.SwitchPlayerState(Player.Instance.stateMachine.playingState);
        // Activate in-game UI features.
        UIManager.Instance.SwitchPanel(UIManager.Instance.inGamePanel);
    }

    public override void UpdateState(GameStateMachine machine)
    {

    }
}
