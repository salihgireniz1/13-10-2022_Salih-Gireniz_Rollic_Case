using UnityEngine;

public class ReadyState : GameState
{
    float startTimer = 0.75f;
    float holdDuration;
    public override void EnterState(GameStateMachine machine)
    {
        // Make player idle.
        Player.Instance.SwitchPlayerState(Player.Instance.stateMachine.idleState);
        // Activate tap to start panel..
        UIManager.Instance.SwitchPanel(UIManager.Instance.tapToStartPanel);
    }

    public override void UpdateState(GameStateMachine machine)
    {
        // Wait for player to tap down.
        if (Input.GetMouseButton(0))
        {
            // If player keeps holding too much,
            // start the game without waiting too much.
            holdDuration += Time.deltaTime;
            if (holdDuration >= startTimer)
            {
                machine.SwitchState(machine.startedState);
            }
            else return;
        }
        else
        {
            // If player releases touch, start the game.
            if (Input.GetMouseButtonUp(0))
            {
                machine.SwitchState(machine.startedState);
            }
        }

    }
}
