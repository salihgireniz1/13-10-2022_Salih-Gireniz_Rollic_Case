using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandleLevelData
{
    int CurrentLevel { get; }
    void SaveLevel();
    int GetCurrentLevel();
    void IncreaseLevel();
}
