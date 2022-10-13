using System.Diagnostics;

public class IdleState : PlayerState
{
    public override void EnterState(PlayerStateMachine machine)
    {
        machine.GetComponent<IApplyForwardSpeed>().CanGoForward = false;
    }
}
