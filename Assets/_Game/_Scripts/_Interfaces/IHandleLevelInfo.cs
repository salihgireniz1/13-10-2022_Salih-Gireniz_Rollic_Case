using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandleLevelInfo
{
    LevelInfoAsset LevelInfoAsset { get; }
    LevelInfo GetLevelInfo(int levelIndex);
}
