public abstract class GameState
{
    public abstract void EnterState(GameStateMachine machine);
    public abstract void UpdateState(GameStateMachine machine);
}
