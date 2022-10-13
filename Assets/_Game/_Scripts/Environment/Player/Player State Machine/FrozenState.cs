public class FrozenState : PlayerState
{
    public override void EnterState(PlayerStateMachine machine)
    {
        machine.GetComponent<IApplyForwardSpeed>().CanGoForward = false;
        machine.GetComponent<IHandleSwerve>().CanSwerve = false;
    }
}
