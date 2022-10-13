public class PlayingState : PlayerState
{
    public override void EnterState(PlayerStateMachine machine)
    {
        machine.GetComponent<IApplyForwardSpeed>().CanGoForward = true;
        machine.GetComponent<IHandleSwerve>().CanSwerve = true;
    }
}
