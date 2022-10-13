using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int startLevelCount;

    [HideInInspector]
    public GameStateMachine stateMachine;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);

        stateMachine = GetComponent<GameStateMachine>();
    }
    private void Start()
    {
        SwitchGameState(stateMachine.readyState);
        LevelManager.Instance.InitializeLevel(startLevelCount);
    }
    public void SwitchGameState(GameState state)
    {
        stateMachine.SwitchState(state);
    }
}