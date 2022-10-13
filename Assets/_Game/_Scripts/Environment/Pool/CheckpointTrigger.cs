using System.Collections;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour, ITriggerPlayer
{
    int maxTriggerCount = 1;
    int triggerCount = 0;
    PoolManager poolRespond;
    private void Awake()
    {
        poolRespond = GetComponentInParent<PoolManager>();
    }
    public void OnTrigger()
    {
        // Let player trigger with this once.
        // Otherwise, it will consider we entered trigger twice,
        // even three times, because u-shaped player model has
        // two arms and a bottom body.
        if (triggerCount >= maxTriggerCount) return;
        triggerCount++;
        // Set game as checkpoint state.
        GameManager.Instance.SwitchGameState
            (GameManager.Instance.stateMachine.checkpointState);

        // Set this pool is IsChecking.
        if (!poolRespond.IsCheking) poolRespond.IsCheking = true;

    }
}
