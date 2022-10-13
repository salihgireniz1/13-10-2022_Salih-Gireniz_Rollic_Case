using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region Properties
    public int FilledAmount
    {
        get => filledAmount;
        set
        {
            filledAmount = value;
            poolText.text = filledAmount + " / " + myPool.PoolSize;
        }
    }
    public float PassedCheckTime
    {
        get => passedCheckTime;
        set => passedCheckTime = value;
    }
    public float MaxCheckTime
    {
        get => maxCheckTime;
    }
    public bool IsCheking { get; set; }
    #endregion

    #region Variables
    [SerializeField]
    private float maxCheckTime; //How long we should wait before failing?

    private float passedCheckTime; //How long has been passed since last ball get into pool.
    private TextMeshPro poolText; // The text on this pool object.
    private int filledAmount; // The total ball count into pool until now.
    private Pool myPool; // The pool class that contains its required properties.
    private IHandlePassProcess passRespond; // Handler of processes once we filled this pool.
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        poolText = GetComponentInChildren<TextMeshPro>();
        passRespond = GetComponent<IHandlePassProcess>();
    }
    private void Update()
    {
        // Return if we are not waiting this pool to be filled yet..
        if (!IsCheking) return;

        // Start timer to check pool filling amount.
        passedCheckTime += Time.deltaTime;

        // If pool is not filled yet..
        if (myPool.FilledAmount < myPool.PoolSize)
        {
            // If it took so long since last ball, sorry you failed..
            if (passedCheckTime >= maxCheckTime)
            {
                Debug.Log("Level Failed.. :(");

                // We are not checking this pool anymore..
                IsCheking = false;
                GameManager.Instance.SwitchGameState
                    (GameManager.Instance.stateMachine.failedState);
            }
        }
        // If pool is already filled, wait for new balls for extra point
        // but not too much..
        else if (passedCheckTime >= maxCheckTime / 2f)
        {
            Debug.Log("Level Completed! :)");

            // We are not checking this pool anymore..
            IsCheking = false;

            // Start pass processes such as animations,
            // setting game state as won etc..
            passRespond.InitPassProcesses();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // If balls get into the pool, well.. Fill the pool.
        if (other.TryGetComponent(out IBall ball))
        {
            PoolOperation.FillPool(myPool, ball.FillAmount);
            // Update latest filled amount of pool to update text on it.
            FilledAmount = myPool.FilledAmount;
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Creates a Pool class for valid PoolManager.
    /// </summary>
    /// <param name="myLevelInfo">The LevelInfo structure of pool's valid level.</param>
    public void InitializeGroundPool(LevelInfo myLevelInfo)
    {
        myPool = new Pool(myLevelInfo.passAmount);
        FilledAmount = myPool.FilledAmount;
    }
    #endregion
}
