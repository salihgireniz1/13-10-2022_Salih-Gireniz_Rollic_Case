using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    #region Constructors
    public GameState readyState = new ReadyState();
    public GameState startedState = new StartedState();
    public GameState checkpointState = new CheckpointState();
    public GameState failedState = new FailedState();
    public GameState wonState = new WonState();
    #endregion

    #region Variables
    GameState currentState;
    #endregion

    #region Methods
    private void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(GameState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }
    #endregion
}
