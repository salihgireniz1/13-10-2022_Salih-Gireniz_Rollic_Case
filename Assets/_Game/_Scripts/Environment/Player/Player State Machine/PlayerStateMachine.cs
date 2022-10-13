using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    #region Constructors
    public PlayerState idleState = new IdleState();
    public PlayerState frozenState = new FrozenState();
    public PlayerState playingState = new PlayingState();
    #endregion

    #region Variables
    PlayerState currentState;

    #endregion
    private void OnEnable()
    {
        if (currentState == null) SwitchState(idleState);
    }
    public void SwitchState(PlayerState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
}
