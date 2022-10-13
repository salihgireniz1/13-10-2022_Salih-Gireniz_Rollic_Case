using System.Collections;
using UnityEngine;

public class PassWithAnimation : MonoBehaviour, IHandlePassProcess
{
    public Transform poolGround;
    public float processTime;
    public PoolType poolType = PoolType.FinalPool;
    public void InitPassProcesses()
    {
        StartCoroutine(PoolPassProcess());
    }
    IEnumerator PoolPassProcess()
    {
        poolGround.GetComponent<Animator>().SetBool("isPassed", true);
        yield return new WaitForSeconds(processTime);
        switch (poolType)
        {
            case PoolType.StepPool:
                // For full game, this can be used. We can set Game state as started,
                // so it will check and keep moving until next pool.
                break;
            case PoolType.FinalPool:
                // Set game as completed with success.
                GameManager.Instance.SwitchGameState(
                    GameManager.Instance.stateMachine.wonState
                    );
                break;
        }
    }
}
