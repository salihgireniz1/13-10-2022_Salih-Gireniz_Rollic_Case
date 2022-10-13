using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LevelDataHandler : MonoBehaviour, IHandleLevelData
{
    #region Constants
    const string LEVEL = "Level";
    #endregion

    #region Properties
    public int CurrentLevel
    {
        get => currentLevel;
        private set => currentLevel = value;
    }
    #endregion

    #region Variables
    private int currentLevel;
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        CurrentLevel = GetCurrentLevel();
    }
    #endregion

    #region Methods
    public void IncreaseLevel()
    {
        // Increase the level index.
        int nextLevelIndex = GetCurrentLevel() + 1;
        CurrentLevel = nextLevelIndex;
        SaveLevel();
    }
    /// <summary>
    /// Update level from inspector.
    /// </summary>
    /// <param name="level">New level index to be set as.</param>
    [Button]
    public void SaveLevel(int level)
    {
        if (level == 0)
        {
            level++;
            Debug.LogWarning("Assigned level cannot be 0. New level is assigned as 1..");
        }
        ES3.Save(LEVEL, level);
    }
    public void SaveLevel()
    {
        ES3.Save(LEVEL, CurrentLevel);
        Debug.Log($"Level {CurrentLevel - 1} passed!\n New Level: {CurrentLevel}");
    }
    public int GetCurrentLevel()
    {
        return ES3.Load(LEVEL, 1);
    }
    #endregion
}