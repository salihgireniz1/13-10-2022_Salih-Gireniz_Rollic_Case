using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public PlayerStateMachine stateMachine;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);

        stateMachine = GetComponent<PlayerStateMachine>();
    }
    public void SwitchPlayerState(PlayerState state)
    {
        stateMachine.SwitchState(state);
    }
}
