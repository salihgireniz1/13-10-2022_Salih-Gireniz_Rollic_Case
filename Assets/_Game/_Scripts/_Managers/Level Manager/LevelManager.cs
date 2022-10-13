using System;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

[RequireComponent(typeof(IHandleLevelInfo))]
[RequireComponent(typeof(IHandleLevelData))]
[RequireComponent(typeof(IGenerateLevel))]
public class LevelManager : MonoBehaviour
{
    #region Properties
    public int NextPoolMemberIndex
    {
        get => nextPoolMemberIndex;
        private set
        {
            nextPoolMemberIndex = value;
            if (nextPoolMemberIndex >= LevelPool.Count - 1)
            {
                AddMemberToPoolList(1);
            }
        }
    }
    public List<GameObject> LevelPool { get; private set; }
    public static LevelManager Instance { get; private set; } // Singleton.
    #endregion

    #region Variables
    IHandleLevelInfo levelInfoRespond; // Level info handler.
    IHandleLevelData levelDataRespond; // Level data handler(save, load etc.)
    IGenerateLevel levelGenerator; // Level prefab handler(spawn,destroy)

    [SerializeField, Space]
    private int levelPoolCount; // Size of level pooling.

    [SerializeField, Space]
    private Transform levelHolder; // Object to store levels into.

    [SerializeField, Space]
    private int nextPoolMemberIndex; // Index of next LevelPool member that we will activate.
    #endregion

    #region MonoBehaviour/Initialize
    void Awake()
    {
        // Init
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);

        levelGenerator = GetComponent<IGenerateLevel>();
        levelInfoRespond = GetComponent<IHandleLevelInfo>();
        levelDataRespond = GetComponent<IHandleLevelData>();

        nextPoolMemberIndex = 0;

        InitializePooling();
    }
    #endregion

    #region Methods

    /// <summary>
    /// Creates an object pool from level prefabs.
    /// </summary>
    public void InitializePooling()
    {
        LevelPool = LevelPooling.GeneratePoolOfLevels
            (
            levelDataRespond.GetCurrentLevel(),
            levelInfoRespond,
            levelPoolCount,
            levelHolder
            );
    }

    /// <summary>
    /// Add a new level member to end of the list.
    /// </summary>
    public void AddMemberToPoolList(int newMemberCount)
    {
        for (int i = 0; i < newMemberCount; i++)
        {
            int nextLevelIndex = levelDataRespond.GetCurrentLevel() + LevelPool.Count;
            LevelInfo nextLevelInfo = levelInfoRespond.GetLevelInfo(nextLevelIndex);
            LevelPooling.GeneratePoolMember(LevelPool, nextLevelInfo, levelHolder);
        }
    }

    /// <summary>
    /// Starts the initializing processes for a new level.
    /// </summary>
    public void LoadNewLevel()
    {
        InitializeLevel(1, true);
        levelDataRespond.IncreaseLevel();
    }

    /// <summary>
    /// Reaches to responds and get current 'LevelInfo' datas.
    /// </summary>
    /// <returns>The structure that includes latest level features.</returns>
    public LevelInfo CollectCurrentLevelInfoDatas()
    {
        // Get the latest level index.
        int levelIndex = levelDataRespond.GetCurrentLevel();

        // Get the 'levelInfo' corresponding the latest level index.
        LevelInfo levelInfo = levelInfoRespond.GetLevelInfo(levelIndex);

        return levelInfo;
    }

    /// <summary>
    /// Activates desired number of levels that LevelPool contains.
    /// </summary>
    /// <param name="levelCountToSpawn">Amount of levels to activate.</param>
    /// <param name="forceToSpawn">Forces manager to spawn only one level more.</param>
    public void InitializeLevel(int levelCountToSpawn, bool forceToSpawn = false)
    {
        if (levelCountToSpawn < 2 && forceToSpawn == false)
        {
            Debug.LogWarning($" Spawning only one level is forbidden.. Initializing two levels..");
            levelCountToSpawn = 2;
        }
        for (int i = 0; i < levelCountToSpawn; i++)
        {
            levelGenerator.SpawnLevel(LevelPool[NextPoolMemberIndex]);
            NextPoolMemberIndex++;
        }
    }

    public int GetCurrentLevel()
    {
        return levelDataRespond.GetCurrentLevel();
    }
    #endregion
}